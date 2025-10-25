---
:title "About"
:description "Learn about BrokerDev's mission to bridge legacy insurance systems with modern AI technology"
:layout "page"
---

<section class="page-header">
  <div class="container">
    <h1>About BrokerDev</h1>
    <p class="subtitle">Bridging the gap between legacy insurance systems and modern AI</p>
  </div>
</section>

<section class="mission">
  <div class="container">
    <h2>Our Mission</h2>
    <p class="large-text">Insurance brokerages shouldn't have to choose between keeping their working legacy systems and leveraging modern AI capabilities. BrokerDev provides the bridge that makes both possible.</p>
  </div>
</section>

<section class="story">
  <div class="container">
    <h2>The Problem We're Solving</h2>

    <p>Insurance brokerages across North America run on systems built in the 1990s—PowerBroker, BMSS, Sig, and others. These platforms were engineering marvels of their era, and they still work reliably today. They hold decades of valuable customer data, policy information, and business intelligence.</p>

    <p>But there's a problem: this data is trapped.</p>

    <p>Modern AI assistants like Claude can transform customer service, automate renewals, identify cross-sell opportunities, and generate insights. But they can't talk to FoxPro databases. They can't navigate proprietary data formats. They can't access your BMS at all.</p>

    <p>The traditional solution is "rip and replace"—spend millions of dollars and years of effort migrating to a modern platform. But that's risky, expensive, and often unnecessary when your current system works just fine.</p>

    <h3>There's a Better Way</h3>

    <p>BrokerDev takes a different approach: <strong>bridge, don't replace</strong>.</p>

    <p>We implement Anthropic's Model Context Protocol (MCP), an open standard for connecting AI assistants to data sources. Our lightweight API layer sits alongside your existing BMS, translating between your legacy data format and modern AI tools.</p>

    <p>All 25,000+ fields across your 356 tables become accessible to AI agents—in real-time, without CSV exports or ETL pipelines.</p>
  </div>
</section>

<section class="approach">
  <div class="container">
    <h2>Our Approach</h2>

    <div class="approach-grid">
      <div class="approach-item">
        <h3>Practical, Not Theoretical</h3>
        <p>We build solutions that work with real-world constraints: 32-bit OleDB drivers, non-standard SQL dialects, undocumented schemas. No ivory tower architecture—just pragmatic engineering.</p>
      </div>

      <div class="approach-item">
        <h3>Preserve What Works</h3>
        <p>Your BMS works. Your staff knows it. Your workflows depend on it. We don't disrupt that. We enhance it by adding a modern integration layer.</p>
      </div>

      <div class="approach-item">
        <h3>Open Standards</h3>
        <p>We implement MCP, an open protocol from Anthropic. Your investment isn't locked to a single vendor. As AI evolves, you evolve with it.</p>
      </div>

      <div class="approach-item">
        <h3>Secure by Design</h3>
        <p>Read-only access by default. Data stays on your premises. Full audit logging. You control what gets exposed and to whom.</p>
      </div>
    </div>
  </div>
</section>

<section class="technology-philosophy">
  <div class="container">
    <h2>Technology Philosophy</h2>

    <h3>Clean Architecture</h3>
    <p>We believe in separation of concerns, dependency injection, and the repository pattern. Our code is maintainable, testable, and extensible.</p>

    <h3>Pluggable Design</h3>
    <p>The provider pattern allows supporting different BMS platforms through the same interface. Today it's PowerBroker; tomorrow it could be Epic or your custom system.</p>

    <h3>Result-Based Error Handling</h3>
    <p>We use functional programming concepts like Result types instead of throwing exceptions for expected failures. This makes our API predictable and easy to integrate with.</p>

    <h3>Domain-Driven Design</h3>
    <p>We model the insurance domain properly: Customers, Policies, Claims, Coverages. Not generic "records" and "fields," but real business concepts.</p>
  </div>
</section>

<section class="team">
  <div class="container">
    <h2>Who We Are</h2>

    <p>BrokerDev was founded by software developers who understand both legacy systems and modern architecture. We've worked in the insurance industry, navigated FoxPro databases, and built production APIs at scale.</p>

    <p>We're not a massive enterprise vendor with a one-size-fits-all platform. We're focused on one thing: making legacy insurance data accessible to modern AI tools, done right.</p>
  </div>
</section>

<section class="open-source">
  <div class="container">
    <h2>Commitment to Open Standards</h2>

    <p>We believe the Model Context Protocol will become the standard way AI assistants connect to data sources—the same way REST became the standard for web APIs.</p>

    <p>By implementing MCP, we ensure our customers aren't locked into a proprietary integration format. As new MCP-compatible AI tools emerge, they'll work with BrokerDev automatically.</p>

    <p>We contribute back to the MCP community, sharing our learnings about integrating with legacy systems and adapting the protocol for insurance-specific use cases.</p>
  </div>
</section>

<section class="roadmap">
  <div class="container">
    <h2>Roadmap</h2>

    <h3>Current Status: Beta</h3>
    <p>We're working with select insurance brokerages to refine the platform. Core functionality is stable: customer lookups, policy queries, interaction history, all accessible via MCP and REST.</p>

    <h3>Near Term</h3>
    <ul>
      <li>Enhanced BI dashboard integrations (Tableau, Power BI)</li>
      <li>Expanded query capabilities for complex analytics</li>
      <li>Additional BMS platform support (Epic, Sig)</li>
      <li>Mobile SDK for custom app development</li>
    </ul>

    <h3>Future Vision</h3>
    <ul>
      <li>Write-capable API for CRM and workflow automation</li>
      <li>Pre-built AI agents for common brokerage tasks</li>
      <li>Real-time event streaming for process automation</li>
      <li>Multi-tenant cloud offering for smaller brokerages</li>
    </ul>
  </div>
</section>

<section class="values">
  <div class="container">
    <h2>Our Values</h2>

    <div class="values-grid">
      <div class="value">
        <h3>Transparency</h3>
        <p>We're honest about what works, what doesn't, and what we're still figuring out. No overpromising.</p>
      </div>

      <div class="value">
        <h3>Pragmatism</h3>
        <p>We ship working software that solves real problems. Perfect is the enemy of done.</p>
      </div>

      <div class="value">
        <h3>Partnership</h3>
        <p>Early adopters help shape the product. Your feedback directly influences our roadmap.</p>
      </div>

      <div class="value">
        <h3>Craftsmanship</h3>
        <p>We care about code quality, architecture, and maintainability—even when working with legacy constraints.</p>
      </div>
    </div>
  </div>
</section>

<section class="cta-section">
  <div class="container">
    <h2>Let's Talk</h2>
    <p>Interested in being an early adopter? Have questions about how BrokerDev could work with your specific BMS? We'd love to hear from you.</p>
    <a href="#contact" class="button primary large">Get in Touch</a>
  </div>
</section>
