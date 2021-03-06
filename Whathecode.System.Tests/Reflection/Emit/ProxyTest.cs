﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Whathecode.Microsoft.VisualStudio.TestTools.UnitTesting;
using Whathecode.System.Reflection.Emit;


namespace Whathecode.Tests.System.Reflection.Emit
{
	[TestClass]
	public class ProxyTest
	{
		public interface ITest<T>
		{
			T GetTest();
			void SetTest( T value );
		}


		public interface IMultipleParametersTest<T1, T2>
		{
			T1 GetT1();
			void SetT1( T1 value );
			T2 GetT2();
			void SetT2( T2 value );
		}


		public interface IExtendedTest<T> : ITest<T>
		{
			T GetExtendedTest();
			void SetExtendedTest( T value );
		}


		public interface IComposition<T>
		{
			ITest<T> GetTest(); 
			void SetTest( ITest<T> test );
		}


		public class InterfaceTest : ITest<string>
		{
			string _value;

			public string GetTest()
			{
				return _value;
			}

			public void SetTest( string value )
			{
				_value = value;
			}
		}


		public class MultipleParametersTest : IMultipleParametersTest<string, int>
		{
			string _t1Value;
			int _t2Value;

			public string GetT1()
			{
				return _t1Value;
			}

			public void SetT1( string value )
			{
				_t1Value = value;
			}

			public int GetT2()
			{
				return _t2Value;
			}

			public void SetT2( int value )
			{
				_t2Value = value;
			}
		}


		public class ExtendedInterfaceTest : IExtendedTest<string>
		{
			string _value;
			string _extendedValue;

			public string GetTest()
			{
				return _value;
			}

			public void SetTest( string value )
			{
				_value = value;
			}

			public string GetExtendedTest()
			{
				return _extendedValue;
			}

			public void SetExtendedTest( string value )
			{
				_extendedValue = value;
			}
		}


		public class CompositionTest : IComposition<string>
		{
			ITest<string> _test = new InterfaceTest();

			public ITest<string> GetTest()
			{
				return _test;
			}

			public void SetTest( ITest<string> test )
			{
				_test = test;
			}
		}


		[TestMethod]
		public void CreateGenericInterfaceWrapperTest()
		{
			const string testString = "test";
			const int testInt = 10;

			// Test interface wrapper.
			var interfaceTest = new InterfaceTest();
			ITest<object> wrappedInterfaceTest = Proxy.CreateGenericInterfaceWrapper<ITest<object>>( interfaceTest );
			wrappedInterfaceTest.SetTest( testString );
			Assert.AreEqual( testString, wrappedInterfaceTest.GetTest() );
			Assert.AreEqual( testString, interfaceTest.GetTest() );
			AssertHelper.ThrowsException<InvalidCastException>( () => wrappedInterfaceTest.SetTest( 0 ) );

			// Test wrapper for interface with multiple parameters.
			var multipleTest = new MultipleParametersTest();
			IMultipleParametersTest<object, object> wrappedMultipleTest
				= Proxy.CreateGenericInterfaceWrapper<IMultipleParametersTest<object, object>>( multipleTest );
			wrappedMultipleTest.SetT1( testString );
			wrappedMultipleTest.SetT2( testInt );
			Assert.AreEqual( testString, wrappedMultipleTest.GetT1() );
			Assert.AreEqual( testInt, wrappedMultipleTest.GetT2() );
			Assert.AreEqual( testString, multipleTest.GetT1() );
			Assert.AreEqual( testInt, multipleTest.GetT2() );
			AssertHelper.ThrowsException<InvalidCastException>( () => wrappedMultipleTest.SetT1( 0 ) );
			AssertHelper.ThrowsException<InvalidCastException>( () => wrappedMultipleTest.SetT2( "bleh" ) );

			// Test wrapper for extending interface.
			var extendedInterfaceTest = new ExtendedInterfaceTest();
			IExtendedTest<object> wrappedExtendedInterfaceTest
				= Proxy.CreateGenericInterfaceWrapper<IExtendedTest<object>>( extendedInterfaceTest );
			wrappedExtendedInterfaceTest.SetTest( testString );
			Assert.AreEqual( testString, wrappedExtendedInterfaceTest.GetTest() );
			Assert.AreEqual( testString, extendedInterfaceTest.GetTest() );
			AssertHelper.ThrowsException<InvalidCastException>( () => wrappedExtendedInterfaceTest.SetTest( 0 ) );

			// Test wrapper for composition interface.
			var compositionTest = new CompositionTest();
			IComposition<object> wrappedCompositionTest = Proxy.CreateGenericInterfaceWrapper<IComposition<object>>( compositionTest );
			ITest<object> innerWrapped = wrappedCompositionTest.GetTest();
			ITest<object> innerWrappedCached = wrappedCompositionTest.GetTest();
			Assert.IsTrue( innerWrapped == innerWrappedCached );  // Check whether the internal wrapper is cached.
			compositionTest.SetTest( new InterfaceTest() );
			ITest<object> innerWrappedUpdated = wrappedCompositionTest.GetTest();
			Assert.IsTrue( innerWrapped != innerWrappedUpdated ); // Check whether cache is updated when wrapped object changes.
			innerWrappedUpdated.SetTest( testString );
			Assert.AreEqual( testString, wrappedCompositionTest.GetTest().GetTest() );
			Assert.AreEqual( testString, compositionTest.GetTest().GetTest() );
			AssertHelper.ThrowsException<InvalidCastException>( () => wrappedCompositionTest.GetTest().SetTest( 0 ) );
		}
	}
}