---
slug: bms-integration-guide
title: Getting Started with BMS Integration
summary: A step-by-step guide to connecting your legacy BMS to modern AI tools.
categories:
  - guides
author: BrokerDev
publishDate: 2025-10-15
---

## Integration Overview

This guide walks you through the process of connecting your legacy BMS to modern AI tools using BrokerDev's MCP API.

### Prerequisites

- Windows Server running your BMS (PowerBroker, BMSS, etc.)
- Network access to your BMS database
- .NET 9.0 runtime installed
- Basic understanding of your BMS database structure

### Step 1: Install the API Server

Download and install the BrokerDev API server on your Windows server. The installation is straightforward and takes about 5 minutes.

### Step 2: Configure Database Connection

Update the configuration file with your BMS database connection details. We support OleDB connections to FoxPro databases, as well as SQL Server connections.

### Step 3: Test the Connection

Use the built-in diagnostic tools to verify that the API can successfully connect to your BMS database and retrieve sample data.

### Step 4: Connect Your AI Tools

Configure your AI assistants (Copilot, ChatGPT, Gemini) to use the MCP server. We provide simple configuration templates for each platform.

### Step 5: Start Querying

You're ready! Start asking questions in natural language and watch as your AI assistant pulls data directly from your BMS.
