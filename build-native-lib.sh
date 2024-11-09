clang++ native-lib.cpp -shared -o native-lib -Xclang -fdump-record-layouts > native-lib-record-layout
# nm -g native-lib > native-lib-exports