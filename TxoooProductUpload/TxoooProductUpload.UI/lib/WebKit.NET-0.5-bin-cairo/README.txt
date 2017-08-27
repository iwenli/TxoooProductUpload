WebKit.NET README
*****************

WebKit.NET is a control library wrapper for WebKit written in C#.

Currently the source code is licensed under a BSD open source license, see
LICENSE.txt for details.

This package contains the binary release of WebKit.NET, along with
the Cairo build of WebKit.  Files included in this release include:

    bin/WebKit.dll - The WebKit library.
    
    bin/WebKitBrowser.dll - The WebKit.NET control library.  Add a reference to
                        this library if you wish to use the control.
                        
    bin/WebKit.Interop.dll - The library WebKit.NET uses to interface to WebKit
                        via COM interop.
                         
    bin/WebBrowserTest.exe - A simple application demonstrating the use of the
                        WebKit.NET control.
                         
    bin/*.dll - Dependencies required by WebKit.dll.
    
    docs/WebKit .NET API Reference.chm - API reference in CHM format.
    


Requirements and using WebKit.NET
*********************************

To run the sample application provided in this package, the .NET framework
version 2.0 must be installed (WebKit.dll may also require some Microsoft
Visual C++ 2008 libraries to be installed, these can be obtained from
download.microsoft.com as Visual C++ redistributable packages).

To use the WebKit.NET control, you must add a reference to WebKitBrowser.dll
from your project.  Visual Studio or Visual C# Express 2008 are recommended.
Visual Studio / C# 2005 has not been tested but should work fine, earlier
versions will not work.  Mono is currently unsupported and untested but support
is planned in the future.  In order for your project to run correctly under
64-bit versions of Windows, you must set the architecture to x86 only in your
project properties.  WebKitBrowser.dll is configured to run only as a 32-bit
process as currently there are no 64-bit builds of WebKit available.
  
As of 0.3, you may need to install an update to the Visual C++ 2008 runtime.
This can be downloaded from:

http://www.microsoft.com/downloads/details.aspx?familyid=a5c84275-3b97-4ab7-a40d-3802b2af5fc2&displaylang=en


