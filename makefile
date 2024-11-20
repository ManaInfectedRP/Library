ifdef OS
	BIN := lib/bin/Debug/net8.0/lib.exe
else
	BIN := lib/bin/Debug/net8.0/lib.bin
endif

default: build run

build: lib
	dotnet build

run: $(BIN)
	$(BIN)