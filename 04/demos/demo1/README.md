# Demo 1 - Visualizing the Service Mesh

Using [Kiali](https://kiali.io) to graph active services and see the traffic flow between them.

## 0.1
Apply with enabling jaeger tracing [operator-tracing](operator-tracing.yaml)

```
istioctl install --set profile=demo  -f operator-tracing.yaml


../../../kube/cleanup.sh


kubectl apply -f ../setup/
```

## 1.0 Apply istio addons:

```
kubectl apply -f <Istio-folder>/samples/addons
```

## 1.1 Publish the Kiali UI

Deploy a [Gateway and VirtualService](kiali.yaml) for Kiali:

```
istioctl dashboard kiali
```

- App graph in _Graph_
- Check `productpage` in Kiali _Workloads_

## 1.2 Canary deployment for v2

Deploy [v2 product page](./v2/productpage-v2-canary.yaml) and [v2 reviews API](./v2/reviews-v2-canary.yaml) updates:

```
kubectl apply -f ./v2/
```

> Browse to http://bookinfo.local/productpage and refresh 

- Back to Kiali
- Switch versioned app graph
- Add _Requests percentage_ label
- Check bookinfo virtual service in _Istio Config_ (editable!)

## 1.3 Generate some load

Use [Fortio](https://fortio.org) to send a few hundred requests to the app:

```
docker run  fortio/fortio load -c 32 -qps 25 -t 30s http://MACHINE_IP/productpage
```

- Back to Kiali _Graph_


> Go to [demo2](../demo2/README.md)