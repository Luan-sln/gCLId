# GUID CLI Tool (gCLId)

A command-line tool for generating and converting GUIDs (Globally Unique Identifiers) in various formats.

## Features

- Generate multiple GUIDs at once
- Convert existing GUIDs to different formats
- Save generated GUIDs to JSON or TXT files
- Support for both Windows and Linux

## Prerequisites

- .NET 8.0 SDK or later
## Installation

### Windows

1. Clone the repository:
```bash
git clone https://github.com/Luan-sln/gCLId.git
cd gclid
```

2. Build the application:
```bash
dotnet build
```

3. Publish the application:
```bash
dotnet publish -c Release -r win-x64 --self-contained false
```

4. Add the published directory to your system PATH:
   - The published files will be in `bin/Release/net8.0/win-x64/publish/`
   - Copy this path and add it to your system's PATH environment variable
   - Or create a symbolic link to the executable in a directory that's already in your PATH

### Linux

1. Clone the repository:
```bash
git clone https://github.com/Luan-sln/gCLId.git
cd gclid
```

2. Build the application:
```bash
dotnet build
```

3. Publish the application:
```bash
dotnet publish -c Release -r linux-x64 --self-contained false
```

4. Add the application to your system:
```bash
# Create a symbolic link to the executable
sudo ln -s "$(pwd)/bin/Release/net8.0/linux-x64/publish/gclid" /usr/local/bin/gclid
```

## Usage

### Generate GUIDs

Generate a single GUID:
```bash
gclid --create 1
```

Generate multiple GUIDs:
```bash
gclid --create 5
```

### Convert a GUID

Convert an existing GUID to different formats:
```bash
gclid --value "00000000-0000-0000-0000-000000000000"
```

### Save GUIDs to File

Save generated GUIDs to a JSON file:
```bash
gclid --create 5 --output guids.json
```

Save generated GUIDs to a TXT file:
```bash
gclid --create 5 --output guids.txt
```

Explicitly specify the output format:
```bash
gclid --create 5 --output output.file --format json
```

## Command Options

- `--value, -v`: The value to generate GUIDs for (for conversion)
- `--create, -c`: Number of GUIDs to generate (default: 1)
- `--output, -o`: Output file path for saving GUIDs (supports .json or .txt)
- `--format, -f`: Output format (json or txt). If not specified, format is determined by file extension

## Output Examples

### JSON Output
```json
[
  {
    "Number": 1,
    "StandardFormat": "12345678-1234-5678-1234-567812345678",
    "NFormat": "12345678123456781234567812345678"
  }
]
```

### TXT Output
```
GUID 1:
  Standard Format: 12345678-1234-5678-1234-567812345678
  N Format: 12345678123456781234567812345678
```

## Troubleshooting

If you encounter any issues:

1. Make sure you have the correct .NET SDK version installed:
```bash
dotnet --version
```

2. Verify the installation:
```bash
gclid --help
```

3. Check if the application is in your PATH:
```bash
# Windows
where gclid

# Linux
which gclid
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details. 