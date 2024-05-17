# Istalling Istio

> Adapted from the [Istio Quick Start](https://istio.io/latest/docs/setup/install/istioctl/)


> install [istioctl](https://istio.io/latest/docs/setup/getting-started/#download), I using `istioctl 1.22.0` at the time of this course but I recommend to install V13.

## 1.1 Deploy Istio

Install `istioctl`:

```
curl -L https://istio.io/downloadIstio | sh -

cd istio-1.17.2

export PATH=$PWD/bin:$PATH
```

Verify that `istioctl` is installed corectly:

Istio [profiles](https://istio.io/latest/docs/setup/additional-setup/config-profiles/)

```
istioctl --help

istioctl profile list

istioctl manifest generate --set profile=demo > istio.yaml
```

Install `Istio` components:
```
istioctl install --set profile=demo
```

## 1.2 Verify Istio

Running objects:

```
kubectl get all -n istio-system
```

> All components have memory requests

## 1.3 Configure auto proxy injection

Configure default namespance:

```
istioctl analyze

kubectl label namespace default istio-injection=enabled
```

Check label:

```
kubectl describe namespace default
```

## 1.4 Check what's running

```
kubectl get all

docker info
```

> Go to [demo2](../demo2/README.md)
