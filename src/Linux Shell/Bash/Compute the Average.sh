#!/bin/bash

read N

sum=0
for (( i=0; i<N; i++ ))
do
    read num
    sum=$((sum + num))
done

average=$(echo "scale=4; $sum / $N" | bc -l)
rounded_average=$(printf "%.3f" $average)

echo "$rounded_average"
