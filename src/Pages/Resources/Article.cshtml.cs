using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BrokerDevWebsite.Pages.Resources;

public class ArticleModel : PageModel
{
    public ResourceArticleDetail? Article { get; set; }

    public IActionResult OnGet(string slug)
    {
        // TODO: Load from markdown files or database
        // For now, using sample data
        var articles = GetAllArticles();
        Article = articles.FirstOrDefault(a => a.Slug == slug);

        if (Article == null)
        {
            return NotFound();
        }

        return Page();
    }

    private List<ResourceArticleDetail> GetAllArticles()
    {
        return new List<ResourceArticleDetail>
        {
            new ResourceArticleDetail
            {
                Slug = "what-is-mcp",
                Title = "What is Model Context Protocol (MCP)?",
                Summary = "Learn how MCP enables AI assistants to securely access your business data.",
                Category = "definitions",
                PublishDate = new DateTime(2025, 10, 20),
                Content = @"
                    <h2>Understanding Model Context Protocol</h2>
                    <p>Model Context Protocol (MCP) is an open standard developed by Anthropic that enables AI assistants to securely connect to your business data and systems.</p>

                    <h3>Why MCP Matters for Insurance Brokerages</h3>
                    <p>Traditional insurance management systems like PowerBroker and BMSS contain decades of valuable data, but this data is trapped in legacy formats that modern AI tools can't easily access.</p>

                    <p>MCP solves this by providing a standardized way for AI assistants like Claude, ChatGPT, and Copilot to:</p>
                    <ul>
                        <li>Query your data in natural language</li>
                        <li>Access information securely without exposing credentials</li>
                        <li>Work with your existing systems without requiring migration</li>
                        <li>Maintain audit logs of all data access</li>
                    </ul>

                    <h3>How It Works</h3>
                    <p>MCP acts as a bridge between AI assistants and your data sources. When you ask an AI a question about your business data, MCP:</p>
                    <ol>
                        <li>Receives the request from the AI assistant</li>
                        <li>Translates it into the appropriate query for your BMS</li>
                        <li>Retrieves the data securely</li>
                        <li>Returns it to the AI in a format it can understand</li>
                    </ol>

                    <p>This all happens on your infrastructure, ensuring your data never leaves your network.</p>
                "
            },
            new ResourceArticleDetail
            {
                Slug = "bms-integration-guide",
                Title = "Getting Started with BMS Integration",
                Summary = "A step-by-step guide to connecting your legacy BMS to modern AI tools.",
                Category = "guides",
                PublishDate = new DateTime(2025, 10, 15),
                Content = @"
                    <h2>Integration Overview</h2>
                    <p>This guide walks you through the process of connecting your legacy BMS to modern AI tools using BrokerDev's MCP API.</p>

                    <h3>Prerequisites</h3>
                    <ul>
                        <li>Windows Server running your BMS (PowerBroker, BMSS, etc.)</li>
                        <li>Network access to your BMS database</li>
                        <li>.NET 9.0 runtime installed</li>
                        <li>Basic understanding of your BMS database structure</li>
                    </ul>

                    <h3>Step 1: Install the API Server</h3>
                    <p>Download and install the BrokerDev API server on your Windows server. The installation is straightforward and takes about 5 minutes.</p>

                    <h3>Step 2: Configure Database Connection</h3>
                    <p>Update the configuration file with your BMS database connection details. We support OleDB connections to FoxPro databases, as well as SQL Server connections.</p>

                    <h3>Step 3: Test the Connection</h3>
                    <p>Use the built-in diagnostic tools to verify that the API can successfully connect to your BMS database and retrieve sample data.</p>

                    <h3>Step 4: Connect Your AI Tools</h3>
                    <p>Configure your AI assistants (Copilot, ChatGPT, Gemini) to use the MCP server. We provide simple configuration templates for each platform.</p>

                    <h3>Step 5: Start Querying</h3>
                    <p>You're ready! Start asking questions in natural language and watch as your AI assistant pulls data directly from your BMS.</p>
                "
            },
            new ResourceArticleDetail
            {
                Slug = "announcing-brokerdev",
                Title = "Announcing BrokerDev",
                Summary = "We're building the bridge between legacy insurance systems and modern AI.",
                Category = "news",
                PublishDate = new DateTime(2025, 10, 1),
                Content = @"
                    <h2>The Problem We're Solving</h2>
                    <p>Insurance brokerages face a unique challenge: their most valuable asset—decades of customer data—is locked away in legacy systems that modern AI tools can't access.</p>

                    <p>Replacing these systems isn't realistic. Migration projects cost millions, take years, and carry enormous risk. But waiting for vendors to modernize means falling behind competitors who are already leveraging AI.</p>

                    <h3>Our Solution</h3>
                    <p>BrokerDev bridges your legacy BMS with modern AI tools through the Model Context Protocol (MCP). No migration required. No data leaves your network. Your current system keeps working exactly as it does today.</p>

                    <h3>What This Means for Brokerages</h3>
                    <p>With BrokerDev, you can:</p>
                    <ul>
                        <li>Ask AI assistants questions about your book of business in plain English</li>
                        <li>Connect Power BI and Tableau directly to your data for real reporting</li>
                        <li>Build custom tools like mobile apps and client portals</li>
                        <li>Automate renewal analysis and identify cross-sell opportunities</li>
                    </ul>

                    <h3>Early Access</h3>
                    <p>We're working with a small group of brokerages to refine the platform. If you're interested in early access, <a href='/contact'>get in touch</a>.</p>

                    <p>We're excited to help brokerages unlock their data and compete in the age of AI.</p>
                "
            }
        };
    }
}

public class ResourceArticleDetail : ResourceArticle
{
    public string Content { get; set; } = string.Empty;
}
