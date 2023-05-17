# Demo 3 - End-user Authorization

Require ned-user authentication with JWT and enforce access control based on the JWT calims.

## 3.0 Pre-reqs

Follow the steps from [Demo 1](../demo1/README.md).

## 3.1 Require JWT authentication

Apply the [JWT authentication policy](productpage-authn-jwt.yaml) for the product page:

```
kubectl apply -f productpage-authn-jwt.yaml
```

## 3.2 Restrict access to product page

Apply a [deny-all authorization policy](productpage-authz-deny-all.yaml) for the product page:

```
kubectl apply -f productpage-authz-deny-all.yaml
```

> Repeat edit & send request -> `403`

> Browse to http://localhost/productpage -> `403`

<div align="center">
<img src="screenshots/productpage-without-auth.png">
<i>access productpage without token</i>
</div>

You need to add an authentication header. In Firefox's network tab:

- Refresh
- Edit & resend 
- Add header

```
Authorization: Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IkRIRmJwb0lVcXJZOHQyenBBMnFYZkNtcjVWTzVaRXI0UnpIVV8tZW52dlEiLCJ0eXAiOiJKV1QifQ.eyJleHAiOjQ2ODU5ODk3MDAsImZvbyI6ImJhciIsImlhdCI6MTUzMjM4OTcwMCwiaXNzIjoidGVzdGluZ0BzZWN1cmUuaXN0aW8uaW8iLCJzdWIiOiJ0ZXN0aW5nQHNlY3VyZS5pc3Rpby5pbyJ9.CfNnxWP2tcnR9q0vxyxweaF3ovQYHYZl82hAUsn21bwQd9zP7c-LS9qd_vpdLG4Tn1A15NxfCjp5f7QNBUo-KC9PJqYpgGbaXhaGx7bEdFWjcwv3nZzvc7M__ZpaCERdwU7igUmJqYGBYQ51vr2njU9ZimyKkfDe3axcyiBZde7G6dabliUosJvvKOPcKIWPccCgefSj_GNfwIip3-SsFdlR7BtbVUcqR-yv-XOxJ3Uc1MI0tz3uMiiZcyPV7sNCU4KRnemRIMHVOfuvHsU60_GhGbiSFzgPTAa9WTltbnarTbxudb_YEOx12JiwYToeX0DCPb43W1tzIBxgm8NxUg
```

> Now http://localhost/productpage -> `403`

## 3.3 Decode the JWT

The JWT is a base64 encoded string. Read the claims - browse to 
 https://jwt.io and paste contents of [demo.jwt](demo.jwt)

- Issuer: `testing@secure.istio.io`
- Subject: `testing@secure.istio.io`
- Custom: `foo=bar`

## 3.4 Allow any valid token

Apply the [productpage auth just valid tokeny](productpage-auth-just-valid-token.yaml) for the product page:

```
kubectl apply -f productpage-auth-just-valid-token.yaml
```

<div align="center">
<img src="screenshots/productpage-with-auth.png">
<i>access productpage with token</i>
</div>

## 3.5 Allow access by issuer

Apply an [authorization policy which allows access by issuer](productpage-authz-allow-issuer.yaml):

```
kubectl apply -f productpage-authz-allow-issuer.yaml
```
> Repeat edit & send request -> `200`

## 3.6 Allow access by subject

Apply an [authorization policy which allows access by subject](productpage-authz-allow-subject.yaml):

```
kubectl apply -f productpage-authz-allow-subject.yaml
```
> Repeat edit & send request -> `403`

<div align="center">
<img src="screenshots/productpage-with-wrong-token.png">
<i>access productpage wrong token</i>
</div>

## 3.7 Allow access by custom claim

Apply an [authorization policy which allows access by claim](productpage-authz-allow-claim.yaml):

```
kubectl apply -f productpage-authz-allow-claim.yaml
```

> Repeat edit & send request -> `200`

> Go to [demo1 in toturial 4](../../../04/demos/demo1/README.md)