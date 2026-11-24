### Login With a Service Principal Secret: FRICKER_SWTT_SPS :

If secret has expired in Azure application / Entra. Update the secret and update the secret in GitHub repository settings.
The whole chunk of the secret is a JSON object with the following structure:

{
    "clientSecret":  "******",
    "subscriptionId":  "e19221f3-218b-45ca-a61b-00fe6b608607",
    "tenantId":  "e7b7a6c3-bb6e-4588-b4e1-5c6b66aab7c8",
    "clientId":  "2bf83d09-def8-4b69-9783-08d9a66d2b6a"
}