#!/bin/bash

read expression

result=$(echo "scale=4; $expression" | bc -l)
rounded_result=$(printf "%.3f" $(echo $result | bc -l))

echo "$rounded_result"
