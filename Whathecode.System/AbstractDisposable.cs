﻿using System;
using System.Runtime.Serialization;


namespace Whathecode.System
{
	/// <summary>
	///   A base implementation for the Disposable pattern, implementing <see cref="IDisposable" />.
	/// </summary>
	/// <author>Steven Jeuris</author>
	[DataContract]
	public abstract class AbstractDisposable : IDisposable
	{
		public event Action OnDisposed;
		bool _isDisposed = false;


		~AbstractDisposable()
		{
			Dispose( false );
		}


		public void Dispose()
		{
			Dispose( true );

			// Destructor doesn't need to be called anymore. The object is already disposed.
			GC.SuppressFinalize( this );
		}

		void Dispose( bool isDisposing )
		{
			if ( _isDisposed )
			{
				return;
			}

			if ( isDisposing )
			{
				FreeManagedResources();
			}
			FreeUnmanagedResources();
			_isDisposed = true;

			Action handler = OnDisposed;
			if ( handler != null )
			{
				handler();
			}
		}

		/// <summary>
		///   This is only called once, when the managed resources haven't been cleaned up yet.
		/// </summary>
		protected abstract void FreeManagedResources();

		/// <summary>
		///   This is only called once, and should clean up all the unmanaged resources.
		/// </summary>
		protected abstract void FreeUnmanagedResources();
	}
}
