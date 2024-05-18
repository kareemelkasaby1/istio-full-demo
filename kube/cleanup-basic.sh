#!/bin/bash

# Namespace to clean up
NAMESPACE="default"

# List of Istio resource types to delete
ISTIO_RESOURCES=(
  "VirtualService"
  "DestinationRule"
  "Gateway"
  "ServiceEntry"
  "Sidecar"
  "PeerAuthentication"
  "AuthorizationPolicy"
  "RequestAuthentication"
  "EnvoyFilter"
)

# Check if namespace exists
kubectl get namespace "$NAMESPACE" &> /dev/null
if [ $? -ne 0 ]; then
  echo "Namespace '$NAMESPACE' does not exist."
  exit 1
fi

# Delete Istio resources
for RESOURCE in "${ISTIO_RESOURCES[@]}"; do
  echo "Deleting $RESOURCE resources in namespace $NAMESPACE..."
  kubectl delete "$RESOURCE" --all -n "$NAMESPACE"
done

echo "All Istio resources in namespace '$NAMESPACE' have been deleted."

# Optionally, delete all other resources in the namespace
echo "Deleting all remaining resources in namespace $NAMESPACE..."
kubectl delete all --all -n "$NAMESPACE"

# Optionally, delete the namespace itself
# echo "Deleting namespace $NAMESPACE..."
# kubectl delete namespace "$NAMESPACE"

echo "Cleanup completed."
