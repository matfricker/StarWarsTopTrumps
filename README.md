### Login With a Service Principal Secret: FRICKER_SWTT_SPS :

If secret has expired in Azure application / Entra. Update the secret and update the secret in GitHub repository settings.
The whole chunk of the secret is a JSON object with the following structure:

{
    "clientSecret":  "******",
    "subscriptionId":  "******",
    "tenantId":  "******",
    "clientId":  "******"
}