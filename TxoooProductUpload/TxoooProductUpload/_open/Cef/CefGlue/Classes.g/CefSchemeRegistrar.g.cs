﻿//
// DO NOT MODIFY! THIS IS AUTOGENERATED FILE!
//
namespace Xilium.CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Xilium.CefGlue.Interop;
    
    // Role: PROXY
    public sealed unsafe partial class CefSchemeRegistrar : IDisposable
    {
        internal static CefSchemeRegistrar FromNative(cef_scheme_registrar_t* ptr)
        {
            return new CefSchemeRegistrar(ptr);
        }
        
        internal static CefSchemeRegistrar FromNativeOrNull(cef_scheme_registrar_t* ptr)
        {
            if (ptr == null) return null;
            return new CefSchemeRegistrar(ptr);
        }
        
        private cef_scheme_registrar_t* _self;
        
        private CefSchemeRegistrar(cef_scheme_registrar_t* ptr)
        {
            if (ptr == null) throw new ArgumentNullException("ptr");
            _self = ptr;
        }
        
        ~CefSchemeRegistrar()
        {
            if (_self != null)
            {
                Release();
                _self = null;
            }
        }
        
        public void Dispose()
        {
            if (_self != null)
            {
                Release();
                _self = null;
            }
            GC.SuppressFinalize(this);
        }
        
        internal void AddRef()
        {
            cef_scheme_registrar_t.add_ref(_self);
        }
        
        internal bool Release()
        {
            return cef_scheme_registrar_t.release(_self) != 0;
        }
        
        internal bool HasOneRef
        {
            get { return cef_scheme_registrar_t.has_one_ref(_self) != 0; }
        }
        
        internal cef_scheme_registrar_t* ToNative()
        {
            AddRef();
            return _self;
        }
    }
}
