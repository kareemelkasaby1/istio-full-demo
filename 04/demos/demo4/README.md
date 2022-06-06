# Demo 4 - Logging from Istio and Envoy

Use the EFK stack - [Elasticsearch](), [Fluentd]() and [Kibana]() to record and search logs.

## 4.1 Deploy the logging stack

Deployments, services etc. in [elasticsearch.yaml](./logging/01_elasticsearch.yaml), [kibana.yaml](./logging/02_kibana.yaml) and [fluentd.yaml](./logging/03_fluentd.yaml):

```
kubectl apply -f ./logging/

kubectl get pods -n logging
```

> Browse to Kibana at http://localhost:443

- In _Discover_ create index pattern for `logstash*`

## 4.2 Generate some load

Running for 30 seconds:

```
docker run  fortio/fortio load -c 32 -qps 25 -t 30s http://MACHINE_IP/productpage
```

- Back to Kibana
- Filter on `kubernetes.labels.app` _is_ `productpage`


> Refresh Kibana at http://localhost:443 

- Filter on `kubernetes.container.name` _is_ `istio-proxy`
- These are Envoy logs 