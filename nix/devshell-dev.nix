{ pkgs }:

pkgs.mkShell {
  buildInputs = [
    pkgs.jdk21           # Java Development Kit
    pkgs.clojure         # Clojure CLI tools
    pkgs.polylith        # Polylith CLI
    pkgs.gh              # GitHub CLI
    pkgs.nodejs          # Node.js (for npx/claude-code)
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

Common commands:
  clj -M:repl                          - Start Clojure REPL
  poly                                 - Run Polylith commands
  poly info                            - Show workspace info
  poly test                            - Run tests
  poly check                           - Check workspace
  claude                               - Run Claude Code CLI
"
  '';
}
