using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libADALiOS.a", LinkTarget.Simulator, Frameworks = "SystemConfiguration Security", ForceLoad = true)]
