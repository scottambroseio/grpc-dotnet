# Derived from https://github.com/grpc/grpc/blob/master/examples/protos/helloworld.proto

$PROTOC="$HOME\.nuget\packages\grpc.tools\1.17.0\tools\windows_x64\protoc.exe";
$PLUGIN="$HOME\.nuget\packages\grpc.tools\1.17.0\tools\windows_x64\grpc_csharp_plugin.exe";
$OUT="./String.Grpc";

# Clean
Remove-Item $OUT/*.cs

# Generate
& $PROTOC --csharp_out $OUT --grpc_out $OUT --plugin=protoc-gen-grpc=$PLUGIN ./string.proto