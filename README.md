# Cwd (Copy current directory)
A simple program that adds functionality that, unfortunately, is not found in many terminals by default. Three letters are enough to quickly copy the current path, do not waste time on long commands or, even worse, taking your hands off the keyboard on the mouse.

## Installation (*Windows*)
Requirements:
- **git** - Cloning the source code from Github.
- **dotnet SDK** - Building the project from source code.

```
# Clone the repository
git clone https://github.com/Krzysztofz01/TKeyChain.git

# Run the install script (for Windows)
./build.cmd

# Run the install script (for Linux)
sudo chmod +x ./build.sh
sudo sh build.sh

# Remember to add the bin directory to the environment variables path
```

## Usage
Run the program with ```-h (--help)``` to display all informations, available commands and arguments.

You can run the program with ```-p (--print)``` to aditional print the current directory.

You use ```-j (--jump)``` to wrap the current directory with ```cd``` and new line symbol to just paste the path to change the directory.

## Development

Features that are not implemented, but that their implementation is planned:

- Support for MacOS systems.