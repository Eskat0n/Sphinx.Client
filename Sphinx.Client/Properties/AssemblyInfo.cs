#region Copyright
// 
// Copyright (c) 2009-2011, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License version 2.1 as published
// by the Free Software Foundation.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
#endregion
#region Usings

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Sphinx search engine .NET client")]
[assembly: AssemblyDescription("Sphinx search engine .NET client")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Sphinx.Client")]
[assembly: AssemblyCopyright("Copyright Rustam Babadjanov 2009-2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("04822705-7c0a-4be7-858f-001ae2942753")]

// Indicates assembly is compliant with the Common Language Specification (CLS). 
[assembly: CLSCompliant(true)]

//  Informs the ResourceManager of the language used to write the neutral culture's resources for an assembly, and can also inform the ResourceManager to use main assembly to retrieve neutral resources using the resource fallback process.
[assembly: NeutralResourcesLanguage("en", UltimateResourceFallbackLocation.MainAssembly)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("0.4.1.0")]
[assembly: AssemblyFileVersion("0.4.1.0")]

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Sphinx.Client.UnitTests")]
[assembly: InternalsVisibleTo("Sphinx.Client1.UnitTests")]
[assembly: InternalsVisibleTo("Sphinx.Client.Explorables")]
