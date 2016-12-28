CSC=xbuild
SOLUTION=RnR.sln

build:
	xbuild /p:Configuration=Debug $(SOLUTION)

release:
	xbuild /p:Configuration=Relase $(SOLUTION)

test:
	mono ./testrunner/NUnit.Runners.2.6.4/tools/nunit-console.exe ./RnR.Tests/bin/Debug/RnR.Tests.dll

nuget:
	nuget restore $(SOLUTION)
	nuget install NUnit.Runners -Version 2.6.4 -OutputDirectory testrunner
