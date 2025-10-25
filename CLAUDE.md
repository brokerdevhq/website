# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Marketing website for BrokerDev - a platform that bridges legacy insurance broker management systems (BMS) with modern AI capabilities. Built as an ASP.NET Core 9.0 Razor Pages application, deployed to Azure App Service.

## Development Commands

### Run the application
```bash
cd src
dotnet run
```
Application runs at `http://localhost:5197`

### Hot reload during development
```bash
cd src
dotnet watch run
```

### Build
```bash
cd src
dotnet build
```

### Publish for production
```bash
cd src
dotnet publish -c Release -o ./publish
```

### Run tests
```bash
cd src
dotnet test
```

## Architecture

### Project Structure
- **ASP.NET Core 9.0** with Razor Pages (not MVC)
- Pages follow Razor Pages pattern: each `.cshtml` has a corresponding `.cshtml.cs` code-behind file
- Static assets in `src/wwwroot/` (css, js, images)
- Shared layout in `src/Pages/Shared/_Layout.cshtml`

### Key Pages
- `Index.cshtml` - Home page with hero, features, use cases, CTAs
- `Contact.cshtml` - Contact form with validation (ContactFormModel in code-behind)
- `Privacy.cshtml` - Privacy policy
- `Error.cshtml` - Error handling page

### Styling Architecture
**Theme System**: The site uses CSS variables for theming (light/dark mode toggle).
- All colors defined as CSS variables in `:root` in `src/wwwroot/css/site.css`
- Theme toggle button in navbar switches between light/dark themes
- JavaScript in `src/wwwroot/js/site.js` handles theme persistence in localStorage

**CSS Files**:
- `site.css` - Main stylesheet with CSS variables and theme system
- `style.css` - Legacy/additional styles (verify which is primary)

### Contact Form
Contact form in `Pages/Contact.cshtml.cs`:
- Uses model binding with `ContactFormModel`
- Validation with data annotations
- Currently logs submissions (email integration TODO)
- Required fields: Name, Email, Company, CurrentSystem (BMS), Message

### Configuration
- Main config: `src/appsettings.json`
- No email service configured yet (placeholder for SendGrid/Azure Communication Services)

## Deployment

### Azure App Service
- App Name: `brokerdev-website`
- Resource Group: `BrokerDev-RG`
- Region: Canada Central
- Runtime: .NET 9.0 on Linux

### CI/CD Pipeline
GitHub Actions workflow (`.github/workflows/azure-deploy.yml`):
- Triggers on push to `main` branch or manual dispatch
- Builds, publishes, and deploys to Azure
- Requires `AZURE_WEBAPP_PUBLISH_PROFILE` secret

### Manual Azure Deployment
```bash
# From src/ directory
dotnet publish -c Release -o ./publish
cd publish
zip -r ../deploy.zip .

az webapp deployment source config-zip \
  --resource-group BrokerDev-RG \
  --name brokerdev-website \
  --src ../deploy.zip
```

## Important Notes

### Routing
Razor Pages uses file-based routing:
- `/` → `Pages/Index.cshtml`
- `/contact` → `Pages/Contact.cshtml`
- `/privacy` → `Pages/Privacy.cshtml`

### Static Assets
.NET 9 uses `MapStaticAssets()` instead of `UseStaticFiles()` - this provides fingerprinting and better caching.

### Theme Implementation
When modifying colors:
1. Update CSS variables in `:root` and `[data-theme="dark"]` selectors
2. Use `var(--variable-name)` throughout CSS, never hardcoded colors
3. Test both light and dark themes

### Mobile Responsiveness
- Navbar uses responsive classes: `.nav-item-mobile-hidden`, `.nav-item-tablet-hidden`
- Test at mobile, tablet, and desktop breakpoints
- Container max-width: 1200px

### Future Work (from README)
- Email integration for contact form (SendGrid/Azure Communication Services)
- Features page (convert from features.md if it exists)
- About page (convert from about.md if it exists)
- Application Insights for monitoring
- Custom domain setup
- SEO meta tags and sitemap.xml
