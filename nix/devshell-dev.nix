{ pkgs }:

pkgs.mkShell {
  buildInputs = [
    pkgs.dotnet-sdk_9
    pkgs.nodejs
    pkgs.gh              # GitHub CLI
    pkgs.roslyn-ls       # Microsoft's official Roslyn language server
  ];

  shellHook = ''
    export APP_ENV="DEV"
    export PATH=$PWD/.nix-profile/bin:$PATH
    export PS1="[\033[1;32mNIX-ENV\033[0m $APP_ENV] $PS1"

    alias claude="npx @anthropic-ai/claude-code"

    echo "
 ██████╗ ██████╗  ██████╗ ██╗  ██╗███████╗██████╗ ██████╗ ███████╗██╗   ██╗
 ██╔══██╗██╔══██╗██╔═══██╗██║ ██╔╝██╔════╝██╔══██╗██╔══██╗██╔════╝██║   ██║
 ██████╔╝██████╔╝██║   ██║█████╔╝ █████╗  ██████╔╝██║  ██║█████╗  ██║   ██║
 ██╔══██╗██╔══██╗██║   ██║██╔═██╗ ██╔══╝  ██╔══██╗██║  ██║██╔══╝  ╚██╗ ██╔╝
 ██████╔╝██║  ██║╚██████╔╝██║  ██╗███████╗██║  ██║██████╔╝███████╗ ╚████╔╝
 ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝╚═════╝ ╚══════╝  ╚═══╝
    "

    echo "
environment:    $APP_ENV
namespace:      ca.brokerdev

Common commands:
  dotnet new webapp -o BrokerDev.Web  - Create new ASP.NET Core web app
  dotnet build                        - Build the solution
  dotnet run                          - Run the application
  dotnet watch                        - Run with hot reload
  claude                              - Run Claude Code CLI
"
  '';
}
