# Variables

$DUMP_PATH="dump"

$FROM_HOST="Cond-Prod-Db-shard-0/cond-prod-db-shard-00-00-fqrqw.mongodb.net:27017,cond-prod-db-shard-00-01-fqrqw.mongodb.net:27017,cond-prod-db-shard-00-02-fqrqw.mongodb.net:27017"
$FROM_USERNAME="Admin"
$FROM_PASSWORD="aYVB9IFmsqx888xy"
$FROM_DB="Conditio-Prod-Db"

# Conditio-Prod-Cluster
# $TO_HOST="Conditio-Prod-Cluster-shard-0/conditio-prod-cluster-shard-00-00-rb4a0.mongodb.net:27017,conditio-prod-cluster-shard-00-01-rb4a0.mongodb.net:27017,conditio-prod-cluster-shard-00-02-rb4a0.mongodb.net:27017"
# $TO_USERNAME="admin"
# $TO_PASSWORD="uFFohGlfQjeZ4lso"
# $TO_DB="Conditio-Prod-Db"

# Conditio-Dev-Cluster
$TO_HOST="Conditio-Dev-Cluster-shard-0/conditio-dev-cluster-shard-00-00-e9qdp.mongodb.net:27017,conditio-dev-cluster-shard-00-01-e9qdp.mongodb.net:27017,conditio-dev-cluster-shard-00-02-e9qdp.mongodb.net:27017"
$TO_USERNAME="admin"
$TO_PASSWORD="mdFdEPs15ALMqOuF"
$TO_DB="Conditio-Dev-Db"

## DUMP THE REMOTE DB
Write-Output "Dumping '$FROM_DB'..."
mongodump --host $FROM_HOST --ssl --username $FROM_USERNAME --password $FROM_PASSWORD --authenticationDatabase admin --db $FROM_DB --out $DUMP_PATH

## RESTORE DUMP DIRECTORY
Write-Output "Restoring to '$TO_DB'..."
mongorestore --host $TO_HOST --ssl --username $TO_USERNAME --password $TO_PASSWORD --authenticationDatabase admin --db $TO_DB "$DUMP_PATH\$FROM_DB"

## REMOVE DUMP FILES
Write-Output "Removing dump files..."
# Remove-Item -r $TO_DUMP_PATH

Write-Output "Done."