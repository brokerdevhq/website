---
slug: microsoft-copilot-mcp-support
title: "Microsoft Brings Model Context Protocol to Copilot Studio and Windows 11"
summary: Microsoft announces comprehensive MCP support across Copilot Studio and native Windows 11 integration, enabling seamless AI-data connections across the entire Microsoft ecosystem.
categories:
  - news
author: BrokerDev
publishDate: 2025-10-25
---

## Microsoft Goes All-In on Model Context Protocol

In a major commitment to open AI standards, Microsoft has announced comprehensive Model Context Protocol support across its ecosystem—from Copilot Studio to native Windows 11 integration.

### Copilot Studio: Available Now

Microsoft has officially added MCP support to Copilot Studio, enabling organizations to connect their AI agents with external knowledge servers and data sources through a standardized framework. According to [Microsoft's official documentation](https://learn.microsoft.com/en-us/microsoft-copilot-studio/agent-extend-action-mcp), Copilot Studio agents can now leverage MCP to access tools and resources from external servers, with configurations automatically inherited and dynamically updated.

### Windows 11: Coming Soon

At [Microsoft Build 2025](https://blogs.microsoft.com/blog/2025/05/19/microsoft-build-2025-the-age-of-ai-agents-and-building-the-open-agentic-web/), Microsoft announced that Windows 11 will deliver "broad first-party support" for MCP as part of the operating system itself—making it the first major OS to natively support the protocol.

## What This Means for Insurance Brokerages

This is a game-changer for the insurance industry. With MCP support in Copilot Studio, brokerages can now:

- **Connect Legacy Systems** - Integrate Copilot directly with existing broker management systems (BMS) like PowerBroker, BMSS, and Applied Epic
- **Unified Data Access** - Access client data, policy information, and claims history through a single, standardized protocol
- **No More Data Silos** - Break down barriers between your BMS, accounting systems, and AI tools
- **Future-Proof Integration** - Build once, work everywhere - MCP connections work across multiple AI platforms

## How MCP Works in Copilot Studio

Microsoft's implementation supports two key MCP capabilities:

### Tools
MCP tools are functions that Copilot agents can call to perform actions on your systems - like retrieving policy data, creating quotes, or updating client information.

### Resources
Resources provide file-like data that agents can read for context, such as API responses, document contents, or database records.

MCP servers automatically expose their tools and resources to Copilot Studio, with all configuration details (names, descriptions, inputs, outputs) inherited from the server. When changes occur on the MCP side, agents automatically access the updated versions.

**Note**: Copilot Studio currently supports MCP tools and resources. Prompt template support is planned for the future. Generative Orchestration must be enabled to use MCP features.

## The BrokerDev Advantage

At BrokerDev, we've been building MCP servers for legacy insurance systems from day one. Our MCP implementation for broker management systems means you're already positioned to take advantage of Microsoft's announcement.

With BrokerDev's MCP server for your BMS:

- ✓ Works immediately with Copilot Studio
- ✓ No additional integration work required
- ✓ Same tools and resources across Claude, Copilot, and other MCP-enabled platforms
- ✓ Automatic updates when you enhance your MCP server

## Real-World Use Cases

Here's what insurance brokerages can do with MCP-connected Copilot agents:

**Client Service**
- "Pull up all policies for ABC Company and check their renewal dates"
- "What's the claims history for this client over the past 3 years?"
- "Find all policies expiring next month that need follow-up"

**Operations**
- "Generate a commission report for producer John Smith for Q3"
- "What's the status of pending certificate requests?"
- "Show me all policies bound this week"

**Compliance**
- "List all policies without current certificates of insurance"
- "Which clients haven't had their annual reviews completed?"

## Windows 11: Native MCP Support Coming

At Microsoft Build 2025, Microsoft announced that Windows 11 will deliver "broad first-party support" for the Model Context Protocol as part of the operating system itself.

This means MCP isn't just available in specific Microsoft products—it's being built into the Windows platform. According to the [Build 2025 announcement](https://blogs.microsoft.com/blog/2025/05/19/microsoft-build-2025-the-age-of-ai-agents-and-building-the-open-agentic-web/), Windows 11 will include:

### Enhanced Authorization
An updated authorization specification that allows users to leverage their existing Windows sign-in methods to grant AI agents secure access to data and services—from personal storage to subscriptions.

### MCP Server Registry
A centralized repository (accessible via [GitHub](https://github.com/modelcontextprotocol/registry)) for public and private MCP server entries, making it easy to discover and connect to available MCP services.

### Cross-Platform Integration
Native Windows 11 MCP support works seamlessly with other Microsoft platforms including GitHub, Copilot Studio, Azure AI Foundry, and Semantic Kernel.

**Timeline**: While no specific GA date has been announced, Microsoft emphasized that security is the "top priority" during implementation, indicating a thoughtful rollout approach.

## Getting Started Today

Microsoft's MCP support is available now in Copilot Studio. To connect your BMS:

1. Enable Generative Orchestration in Copilot Studio
2. Configure your MCP server connection
3. Your BMS tools and resources automatically become available to agents

When Windows 11 native support launches, your existing MCP servers will work automatically—no additional integration needed.

## What This Means for the Industry

Microsoft's adoption of MCP is a watershed moment. With major platforms like Claude and now Microsoft Copilot supporting the protocol, MCP is becoming the de facto standard for AI-data integration.

For insurance brokerages, this means:
- **Lower Integration Costs** - Build once, connect to multiple AI platforms
- **Faster Innovation** - New AI tools can connect to your existing MCP servers
- **Vendor Independence** - Not locked into a single AI platform
- **Future-Proof** - MCP support expanding across the AI ecosystem

### Want to Learn More?

Interested in connecting your BMS to Copilot Studio through MCP? [Request early access](/contact) to BrokerDev and we'll help you get started.

---

**Resources**:
- [Microsoft Learn: MCP in Copilot Studio](https://learn.microsoft.com/en-us/microsoft-copilot-studio/agent-extend-action-mcp)
- [Microsoft Build 2025: AI Agents and the Open Agentic Web](https://blogs.microsoft.com/blog/2025/05/19/microsoft-build-2025-the-age-of-ai-agents-and-building-the-open-agentic-web/)
- [MCP Server Registry on GitHub](https://github.com/modelcontextprotocol/registry)
- [Model Context Protocol Specification](https://modelcontextprotocol.io)
