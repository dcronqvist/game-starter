ifeq ($(OS),Windows_NT)
SHELL := pwsh.exe
.SHELLFLAGS := -NoProfile -Command
endif

# project_name_snake should be the name of the .sln file in src/
project_name_snake := $(shell pwsh -c "Get-ChildItem src/*.sln | Select-Object -First 1 | Foreach BaseName")
project_name_pascal := $(shell pwsh .utils/snake_to_pascal.ps1 $(project_name_snake))
current_directory := $(shell pwsh -c "(Get-Location | Foreach Path) -replace '\\', '/'")

debug_args := {"type":"coreclr","request":"launch","program":"$(current_directory)/src/$(project_name_snake)/bin/Debug/net7.0/$(project_name_snake).dll","cwd":"$(current_directory)"}
encoded_debug_args := $(shell pwsh .utils/url-encode.ps1 '$(debug_args)')

project_files := $(wildcard src/**/*.cs)
project_files += $(wildcard src/**/*.csproj)

# MAIN TARGETS

.PHONY: debug run clean
debug: src/$(project_name_snake)/bin/Debug/net7.0/$(project_name_snake).dll $(project_files)
	@Start-Process "vscode-insiders://fabiospampinato.vscode-debug-launcher/launch?args=$(encoded_debug_args)"

run: src/$(project_name_snake)/bin/Release/net7.0/$(project_name_snake).dll $(project_files)
	@dotnet run --project src/$(project_name_snake)/$(project_name_snake).csproj --configuration Release

clean:
	@Remove-Item "src/$(project_name_snake)/bin" -Recurse -Force
	@Remove-Item "src/$(project_name_snake)/obj" -Recurse -Force

src/$(project_name_snake)/bin/Debug/net7.0/$(project_name_snake).dll: modules/Symphony/Symphony/bin/Release/net6.0/Symphony.dll $(project_files)
	dotnet build src/$(project_name_snake)/$(project_name_snake).csproj -c Debug

src/$(project_name_snake)/bin/Release/net7.0/$(project_name_snake).dll: modules/Symphony/Symphony/bin/Release/net6.0/Symphony.dll $(project_files)
	dotnet build src/$(project_name_snake)/$(project_name_snake).csproj -c Release

# UTILITY TARGETS

.PHONY: show_name rename_project
show_name:
	@Write-Host "Snake case: $(project_name_snake)"
	@Write-Host "Pascal case: $(project_name_pascal)"

rename_project:
	$(eval NEW_NAME = $(shell pwsh -c "Read-Host 'New project name (snake case)'"))
	@Write-Host "Renaming project to '$(NEW_NAME)'"
	@pwsh .utils/rename.ps1 $(project_name_snake) $(NEW_NAME)

# DEPENDENCIES

modules/Symphony/Symphony/Symphony.csproj:
	git submodule update --init --recursive modules/Symphony

modules/Symphony/Symphony/bin/Release/net6.0/Symphony.dll: modules/Symphony/Symphony/Symphony.csproj
	dotnet build modules/Symphony/Symphony/Symphony.csproj -c Release