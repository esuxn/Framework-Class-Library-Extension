﻿using System;
using Whathecode.System.Windows.DependencyPropertyFactory.Aspects;
using Whathecode.System.Windows.DependencyPropertyFactory.Attributes;


namespace BlendCompatibilityTest
{
	/// <summary>
	///   Interaction logic for UserControlTest.xaml
	/// </summary>
	[WpfControl( typeof( Properties ) )]
	public partial class AspectUserControlTest
	{
		[Flags]
		public enum Properties
		{
			AspectProperty
		}


		[DependencyProperty( Properties.AspectProperty, DefaultValue = "Aspect property works!" )]
		public string AspectProperty { get; set; }


		public AspectUserControlTest()
		{
			InitializeComponent();
		}
	}
}