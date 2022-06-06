# Deploying an Istio-managed app

> We're using a modified version of the [Istio BookInfo sample app](https://github.com/istio/istio/tree/master/samples/bookinfo)

## 2.1 Deploy BookInfo

Deploy the app ([bookinfo-v1.yaml](./bookinfo-v1.yaml)):

```
kubectl apply -f bookinfo-v1.yaml
```

And the gateway ([bookinfo-gateway.yaml](./bookinfo-gateway.yaml)):

```
kubectl apply -f bookinfo-gateway.yaml
```

## 2.2 Verify the install

Check pods:

```
kubectl get pods
```

Check gateway:

```
kubectl get svc istio-ingressgateway -n istio-system
```

> Browse to http://localhost/productpage

## 2.3 Check pods have proxy auto-injected

Show the productpage proxy setup:

```
kubectl describe pods -l app=productpage
```

Find all proxy containers:

```
docker container ls --filter name=istio-proxy
```

Check proxy processes for the product page:

```
docker container ls --filter name=istio-proxy_productpage -q

docker container top $(docker container ls --filter name=istio-proxy_productpage -q)
```
> Go to [demo3](../demo3/README.md)