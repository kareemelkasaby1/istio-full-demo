#!/bin/bash

export GATEWAY_URL=localhost

# Check if GATEWAY_URL is set
if [ -z "$GATEWAY_URL" ]; then
  echo "Error: GATEWAY_URL is not set."
  exit 1
fi

# Loop to send 100 curl requests
for i in $(seq 1 200); do
  curl -s -o /dev/null "http://$GATEWAY_URL/productpage"
done

echo "Completed 200 requests to http://$GATEWAY_URL/productpage"
