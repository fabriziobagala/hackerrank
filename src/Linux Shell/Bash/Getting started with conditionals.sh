#!/bin/bash

read -n1 ch

case $ch in
    [Yy]) echo "YES" ;;
    [Nn]) echo "NO" ;;
esac
