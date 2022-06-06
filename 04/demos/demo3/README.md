# Demo 3 - Distributed Tracing

Using [Jaegar](https://www.jaegertracing.io) to visualize trace spans and investigate outliers.

## 3.1 Publish the Jaegar UI

Deploy a [Gateway and VirtualService](jaegar.yaml) for Jaegar:

```
istioctl dashboard jaegar
```

> Browse to http://localhost:15032 

- Select service `productpage.default`
- Follow traces - OK & failing
- Zoom into timeline & check tags

## 3.2 Add service latency

Update the [product page](productpage-delay.yaml) to add 10s delays:

```
kubectl apply -f productpage-delay.yaml
```

> Check http://bookinfo.local/productpage & refresh

Generate some load:

```
docker run  fortio/fortio load -c 32 -qps 25 -t 30s http://MACHINE_IP/productpage
```

- Back to Jaegar
- Follow trace for outlier

> Go to [demo4](../demo4/README.md)