---
:title "Features"
:description "BrokerDev's comprehensive feature set for connecting legacy insurance systems to modern AI"
:layout "page"
---

<section class="page-header">
  <div class="container">
    <h1>Features</h1>
    <p class="subtitle">Everything you need to bridge legacy insurance data with modern AI</p>
  </div>
</section>

<section class="feature-detail">
  <div class="container">
    <h2>Model Context Protocol Implementation</h2>
    <p>BrokerDev implements Anthropic's Model Context Protocol (MCP), the emerging open standard for connecting AI assistants to data sources.</p>

    <div class="feature-benefits">
      <div class="benefit">
        <h3>JSON-RPC 2.0 Protocol</h3>
        <p>Standards-compliant implementation supporting both request/response and streaming patterns for AI interactions.</p>
      </div>

      <div class="benefit">
        <h3>Dual Protocol Support</h3>
        <p>Access your data through traditional REST endpoints or MCP tools, depending on your use case.</p>
      </div>

      <div class="benefit">
        <h3>Future-Proof Architecture</h3>
        <p>As AI capabilities evolve, MCP ensures compatibility with new AI assistants and features without rewriting integrations.</p>
      </div>
    </div>
  </div>
</section>

<section class="feature-detail alt">
  <div class="container">
    <h2>Comprehensive Data Access</h2>
    <p>Access the complete schema of your legacy BMS through clean, well-documented interfaces.</p>

    <h3>Customer Data</h3>
    <ul>
      <li>Customer lookup by ID, email, or name</li>
      <li>Complete customer profiles with contact information</li>
      <li>Interaction history and notes</li>
      <li>Relationship hierarchies and referrals</li>
    </ul>

    <h3>Policy Information</h3>
    <ul>
      <li>Policy details across all lines of business</li>
      <li>Coverage limits and deductibles</li>
      <li>Premium history and payment schedules</li>
      <li>Renewal dates and status tracking</li>
    </ul>

    <h3>Claims & Documents</h3>
    <ul>
      <li>Claims history by customer or policy</li>
      <li>Document metadata and references</li>
      <li>Activity logs and audit trails</li>
    </ul>
  </div>
</section>

<section class="feature-detail">
  <div class="container">
    <h2>Flexible Deployment Options</h2>

    <div class="deployment-options">
      <div class="option">
        <h3>🏢 On-Premises</h3>
        <p>Deploy on your Windows Server alongside your existing BMS. Data never leaves your network.</p>
      </div>

      <div class="option">
        <h3>☁️ Cloud-Connected</h3>
        <p>Optionally expose specific endpoints for remote access or cloud-based BI tools with full security controls.</p>
      </div>

      <div class="option">
        <h3>🔌 Hybrid Architecture</h3>
        <p>Run the API on-premises while connecting to cloud-based AI assistants through secure, encrypted channels.</p>
      </div>
    </div>
  </div>
</section>

<section class="feature-detail alt">
  <div class="container">
    <h2>Pluggable Data Providers</h2>
    <p>Our provider architecture supports multiple data sources and deployment scenarios.</p>

    <h3>FoxPro Provider</h3>
    <p>Production-ready provider for PowerBroker and other FoxPro-based systems using OleDB connectivity on Windows.</p>

    <h3>CSV Provider</h3>
    <p>Development and testing provider for cross-platform work and demo scenarios.</p>

    <h3>Custom Providers</h3>
    <p>Extensible architecture allows adding support for Epic, Sig, or other BMS platforms through the same interface.</p>
  </div>
</section>

<section class="feature-detail">
  <div class="container">
    <h2>Security & Compliance</h2>

    <div class="security-features">
      <div class="security-item">
        <h3>🔐 Read-Only by Default</h3>
        <p>Database connections are read-only to protect your production system from accidental modifications.</p>
      </div>

      <div class="security-item">
        <h3>📝 Full Audit Logging</h3>
        <p>Every API call and MCP tool invocation is logged with timestamps, user context, and query details.</p>
      </div>

      <div class="security-item">
        <h3>🛡️ Role-Based Access</h3>
        <p>Configure which users and AI agents can access specific data types and queries.</p>
      </div>

      <div class="security-item">
        <h3>🔒 Encrypted Connections</h3>
        <p>TLS/SSL support for all API communications, with configurable certificate management.</p>
      </div>
    </div>
  </div>
</section>

<section class="feature-detail alt">
  <div class="container">
    <h2>Developer-Friendly</h2>

    <h3>Clean API Design</h3>
    <p>RESTful endpoints following best practices, with consistent error handling and response formats.</p>

    <h3>Comprehensive Documentation</h3>
    <p>OpenAPI/Swagger specifications, example queries, and integration guides for common scenarios.</p>

    <h3>SDK Support</h3>
    <p>Client libraries for .NET, Node.js, and Python to accelerate your custom development.</p>

    <h3>Local Development Environment</h3>
    <p>CSV provider enables development and testing on macOS or Linux without a Windows environment.</p>
  </div>
</section>

<section class="technical-specs">
  <div class="container">
    <h2>Technical Specifications</h2>

    <div class="specs-grid">
      <div class="spec">
        <h3>Platform</h3>
        <p>ASP.NET Core 8.0+, runs on Windows Server 2016+</p>
      </div>

      <div class="spec">
        <h3>Database</h3>
        <p>FoxPro via OleDB (32-bit), extensible to SQL Server, PostgreSQL</p>
      </div>

      <div class="spec">
        <h3>Protocols</h3>
        <p>HTTP/HTTPS REST, JSON-RPC 2.0 (MCP)</p>
      </div>

      <div class="spec">
        <h3>Authentication</h3>
        <p>API keys, JWT tokens, Windows authentication</p>
      </div>

      <div class="spec">
        <h3>Data Format</h3>
        <p>JSON responses, streaming support for large datasets</p>
      </div>

      <div class="spec">
        <h3>Performance</h3>
        <p>Sub-second queries for typical customer/policy lookups</p>
      </div>
    </div>
  </div>
</section>

<section class="cta-section">
  <div class="container">
    <h2>See It in Action</h2>
    <p>Schedule a demo to see how BrokerDev can unlock your legacy insurance data for modern AI applications.</p>
    <a href="#contact" class="button primary large">Request a Demo</a>
  </div>
</section>
