#!/bin/bash

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null && pwd )"

PRIVATE_PEM=$DIR/private.pem
PUBLIC_PEM=$DIR/public.pem
PFX=$DIR/cert.pfx
PASSWD=$1

if [ -z "$PASSWD" ]
then
    PASSWD="password"
fi

echo "Creating Private Key"
openssl genrsa 2048 > $PRIVATE_PEM

echo "Creating Public Key"
echo """RU
Russian Federation
Yekaterinburg
Kontur Web Courses
.
Dev
""" | openssl req -x509 -days 1000 -new -key $PRIVATE_PEM -out $PUBLIC_PEM

echo ""
echo "Creating Certificate"

openssl pkcs12 -export -in $PUBLIC_PEM -inkey $PRIVATE_PEM -out $PFX -password pass:$PASSWD
