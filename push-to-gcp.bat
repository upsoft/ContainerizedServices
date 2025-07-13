docker tag servicea me-west1-docker.pkg.dev/edu-gcp-moe-it-labs-udipe/my-images-repo/backendapi
docker push me-west1-docker.pkg.dev/edu-gcp-moe-it-labs-udipe/my-images-repo/backendapi

docker tag frontendservice me-west1-docker.pkg.dev/edu-gcp-moe-it-labs-udipe/my-images-repo/frontendapi
docker push me-west1-docker.pkg.dev/edu-gcp-moe-it-labs-udipe/my-images-repo/frontendapi

@rem REM gcloud auth login
@rem REM gcloud auth application-default login
@rem REM gcloud auth configure-docker me-west1-docker.pkg.dev

@rem REM gcloud auth configure-docker
