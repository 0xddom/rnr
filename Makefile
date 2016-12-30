CSC=xbuild
SOLUTION=RnR.sln

FONT_FILES=C64.font Cheepicus_12x12.png Cheepicus12.font IBM.font IBM8x16.png Yayo_c64.png

build: nuget
	xbuild /p:Configuration=Debug $(SOLUTION)
	cp -r RnR/Assets/* RnR/bin/Debug/

release: nuget
	xbuild /p:Configuration=Release $(SOLUTION)
	cp -r RnR/Assets/* RnR/bin/Release/

test: build
	mono ./testrunner/NUnit.Runners.2.6.4/tools/nunit-console.exe ./RnR.Tests/bin/Debug/RnR.Tests.dll

nuget:
	nuget restore $(SOLUTION)
	nuget install NUnit.Runners -Version 2.6.4 -OutputDirectory testrunner

%.font: RnR/Assets/%.font
	cp $^ $@

%.png: RnR/Assets/%.png
	cp $^ $@

run: build $(FONT_FILES)
	mono RnR/bin/Debug/RnR.exe
	rm $(FONT_FILES)

run-release: release $(FONT_FILES)
	mono RnR/bin/Release/RnR.exe
	rm $(FONT_FILES)
