#!/bin/bash

if [ -n "$AWS_ACCESS_KEY_ID" ] && [ -n "$AWS_SECRET_ACCESS_KEY" ] && [ -n "$AWS_DEFAULT_REGION" ] && [ -n "$AWS_PROFILE" ]; then
    echo "Configuring AWS CLI..."
    
    mkdir -p ~/.aws
    
    aws configure set profile.${AWS_PROFILE}.aws_access_key_id ${AWS_ACCESS_KEY_ID}
    aws configure set profile.${AWS_PROFILE}.aws_secret_access_key ${AWS_SECRET_ACCESS_KEY}
    aws configure set profile.${AWS_PROFILE}.region ${AWS_DEFAULT_REGION}
    
    echo "AWS configuration complete. Verifying identity:"
    aws sts get-caller-identity --profile ${AWS_PROFILE}
else
    echo "AWS environment variables not set. Skipping AWS configuration."
fi

echo "Starting application..."