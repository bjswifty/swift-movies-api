## Plan — high-level steps

- Publish your app for Release.
- Prepare the Windows server (install Hosting Bundle).
- Copy the published files to the server.
- Create an IIS Site + App Pool pointing at the publish folder.
- Configure bindings, environment variables, and permissions.
- (Optional) Add automated deploy (Web Deploy / CI/CD).

## Quick step-by-step (IIS on Windows)

- **Publish:** Run on your dev machine or CI to create the deployable artifacts:

```powershell
dotnet publish -c Release -o ./publish
```

- **Install runtime & IIS support:** On the server, install the matching ASP.NET Core Hosting Bundle for your target runtime (this installs the runtime and the ASP.NET Core Module (ANCM) used by IIS).

- **Copy files:** Copy the `./publish` folder to the server (SMB, RDP, scp, or Web Deploy). Suggested location:

```
C:\inetpub\wwwroot\swift-movies-api
```

- **IIS App Pool:** In IIS Manager create an App Pool with these settings:
	- **.NET CLR Version:** No Managed Code
	- **Identity:** Leave as ApplicationPoolIdentity (or use a dedicated service account if the app needs special resource access)

- **Create Site:** In IIS Manager add a new Site:
	- **Physical path:** the publish folder on the server
	- **App Pool:** the pool created above
	- **Binding:** host name and port (default HTTP 80)

- **Permissions:** Ensure the App Pool identity has Read (and Write if required) access to the publish folder.

- **web.config:** Keep the `web.config` that `dotnet publish` generates; it configures ANCM to forward requests to Kestrel.

- **Environment & secrets:** Set `ASPNETCORE_ENVIRONMENT` and connection strings as server environment variables or use secure configuration stores; avoid committing secrets to source.

- **Firewall:** Open port 80 (and 443 if enabling TLS).

- **Verify & logs:** Browse the site. If it fails, check:
	- Windows Event Viewer (Application) for ANCM errors
	- `stdout` logs controlled by `web.config` (enable temporarily for debugging)

- **HTTPS (optional):** For production, bind port 443 and install a certificate (IIS → Server Certificates → Bindings). For free TLS, consider Let's Encrypt with win-acme.

## Optional deployment enhancements

- **Web Deploy:** Use Web Deploy for automated pushes from Visual Studio or CI.
- **CI/CD:** Add a pipeline (GitHub Actions, Azure DevOps, etc.) that runs `dotnet publish` and deploys artifacts to the server.
- **Containers:** Consider Docker for portability and consistent runtime environments.

## Notes specific to this repo

- The project targets `.NET 6` (`net6.0`) — install the matching Hosting Bundle on the server.
- `dotnet publish` will include `web.config` and the compiled app ready for IIS hosting.

---
If you want, I can:

- Provide an exact `dotnet publish` command and an IIS checklist tailored to this repo.
- Generate a PowerShell script to publish and copy the published files to a remote Windows server.