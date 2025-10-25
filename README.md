# BrokerDev Website

Marketing website for BrokerDev - bridging legacy insurance systems with modern AI.

## Project Structure

```
website/
├── src/                             # ASP.NET Core Razor Pages application
│   ├── Pages/                       # Razor pages
│   │   ├── Index.cshtml            # Home page
│   │   ├── Contact.cshtml          # Contact form page
│   │   └── Shared/                 # Shared layout and partials
│   ├── wwwroot/                    # Static files
│   │   ├── css/                    # Stylesheets
│   │   │   └── site.css            # Main stylesheet (organized by sections)
│   │   └── js/                     # JavaScript files
│   │       └── site.js             # Theme toggle functionality
│   ├── appsettings.json            # Base configuration
│   ├── appsettings.Development.json # Development overrides
│   └── appsettings.Production.json  # Production overrides
├── .github/workflows/              # GitHub Actions CI/CD
├── .azure/                         # Azure CLI configuration
├── .gitignore                      # Git ignore rules
└── CLAUDE.md                       # Claude Code documentation
```

## Features

- **Home Page**: Full marketing site with hero, features, use cases, and CTAs
- **Contact Form**: Functional contact form with server-side validation
- **Responsive Design**: Mobile-first, fully responsive layout
- **Dark/Light Theme**: System-aware theme toggle with localStorage persistence
- **Clean CSS**: Well-organized stylesheet with clear section markers
- **Security Headers**: Production-ready security middleware
- **Azure Ready**: Configured for Azure App Service deployment

## Local Development

### Prerequisites

- .NET 9.0 SDK or later
- Your favorite code editor (VS Code, Visual Studio, Rider, etc.)

### Run Locally

```bash
cd src
dotnet restore
dotnet run
```

The application will be available at `http://localhost:5197`

### Development Commands

```bash
# Build the project
dotnet build

# Run in watch mode (hot reload)
dotnet watch run

# Run tests (if any)
dotnet test

# Publish for production
dotnet publish -c Release -o ./publish
```

## Deployment to Azure App Service

### Option 1: Using Azure CLI

1. **Login to Azure**:
   ```bash
   az login
   ```

2. **Create Resource Group** (if not exists):
   ```bash
   az group create --name BrokerDev-RG --location canadacentral
   ```

3. **Create App Service Plan**:
   ```bash
   az appservice plan create \
     --name BrokerDev-Plan \
     --resource-group BrokerDev-RG \
     --sku B1 \
     --is-linux
   ```

4. **Create Web App**:
   ```bash
   az webapp create \
     --name brokerdev-website \
     --resource-group BrokerDev-RG \
     --plan BrokerDev-Plan \
     --runtime "DOTNETCORE:9.0"
   ```

5. **Deploy**:
   ```bash
   cd src
   dotnet publish -c Release -o ./publish
   cd publish
   zip -r ../deploy.zip .

   az webapp deployment source config-zip \
     --resource-group BrokerDev-RG \
     --name brokerdev-website \
     --src ../deploy.zip
   ```

### Option 2: Using GitHub Actions (Recommended)

1. **Download Publish Profile**:
   ```bash
   az webapp deployment list-publishing-profiles \
     --name brokerdev-website \
     --resource-group BrokerDev-RG \
     --xml
   ```

2. **Add GitHub Secret**:
   - Go to your GitHub repository
   - Settings → Secrets and variables → Actions
   - Create new secret: `AZURE_WEBAPP_PUBLISH_PROFILE`
   - Paste the publish profile XML

3. **Push to Main Branch**:
   The GitHub Actions workflow (`.github/workflows/azure-deploy.yml`) will automatically:
   - Build the application
   - Run tests
   - Deploy to Azure App Service

### Option 3: Using Visual Studio / VS Code

- Right-click the project → Publish
- Choose Azure → Azure App Service (Linux)
- Follow the wizard to create and deploy

## Configuration

### Email Integration (TODO)

To enable contact form email notifications:

1. **Add SendGrid/Azure Communication Services**:
   ```bash
   dotnet add package SendGrid
   # or
   dotnet add package Azure.Communication.Email
   ```

2. **Update appsettings.json**:
   ```json
   {
     "EmailSettings": {
       "ApiKey": "your-api-key",
       "FromEmail": "info@brokerdev.ca",
       "ToEmail": "team@brokerdev.ca"
     }
   }
   ```

3. **Update Contact.cshtml.cs**:
   Implement email sending in the `OnPost` method.

### Custom Domain

1. **Add Custom Domain in Azure**:
   ```bash
   az webapp config hostname add \
     --webapp-name brokerdev-website \
     --resource-group BrokerDev-RG \
     --hostname www.brokerdev.ca
   ```

2. **Enable HTTPS**:
   ```bash
   az webapp config ssl bind \
     --name brokerdev-website \
     --resource-group BrokerDev-RG \
     --certificate-thumbprint <thumbprint> \
     --ssl-type SNI
   ```

## Environment Variables (Azure App Service)

Set these in Azure Portal → Configuration → Application settings:

- `ASPNETCORE_ENVIRONMENT`: `Production`
- `EmailSettings__ApiKey`: Your SendGrid/email API key
- `EmailSettings__FromEmail`: `info@brokerdev.ca`
- `EmailSettings__ToEmail`: Your recipient email

## Monitoring

### Application Insights

Add Application Insights for monitoring:

```bash
dotnet add package Microsoft.ApplicationInsights.AspNetCore
```

Update `Program.cs`:
```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

### Logs

View logs in Azure:
```bash
az webapp log tail \
  --name brokerdev-website \
  --resource-group BrokerDev-RG
```

## Tech Stack

- **Framework**: ASP.NET Core 9.0 Razor Pages
- **Styling**: Custom CSS with CSS Variables
- **Hosting**: Azure App Service (Linux)
- **CI/CD**: GitHub Actions

## Next Steps

1. [ ] Add Features page
2. [ ] Add About page
3. [ ] Implement email sending for contact form
4. [ ] Add Application Insights monitoring
5. [ ] Set up custom domain
6. [ ] Add Google Analytics or similar
7. [ ] Add blog/resources section
8. [ ] Optimize images and assets
9. [ ] Add meta tags for SEO
10. [ ] Set up sitemap.xml

## License

Proprietary - BrokerDev
