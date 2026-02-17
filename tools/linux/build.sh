#!/usr/bin/bash

REPO_ROOT="$(git rev-parse --show-toplevel)";
OUTPUT_DIR="${REPO_ROOT}/docs/data";
OUTPUT_FILE="${OUTPUT_DIR}/readme-paths.txt";

mkdir -pv "$OUTPUT_DIR";

find "${REPO_ROOT}" -type f -iname "readme.md" -print0 \
    | while IFS= read -r -d '' file; do
        echo -e "${file#$REPO_ROOT/}";
done > "$OUTPUT_FILE";

echo "${OUTPUT_FILE} generated successfully.";
