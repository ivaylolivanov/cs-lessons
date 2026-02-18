#!/usr/bin/bash

REPO_ROOT="$(git rev-parse --show-toplevel)";
OUTPUT_DIR="${REPO_ROOT}/docs/data";
OUTPUT_FILE="${OUTPUT_DIR}/readme-paths.txt";

function generate_files_list()
{
    local file_readme='';
    local file_cs='';
    local directory='';

    local cs_files=();
    local readme_files=( $(IFS=$'\n'; find "${REPO_ROOT}" -type f -iname "readme.md";) );

    for file_readme in "${readme_files[@]}"; do
        directory="$(dirname "${file_readme}")";
        cs_files=( $(IFS=$'\n'; find "${directory}" -type f -iname "Program.cs") );

        echo "${file_readme}";
        for file_cs in "${cs_files[@]}"; do
            echo "${file_cs#${REPO_ROOT}/}";
        done
    done
}

mkdir -pv "$OUTPUT_DIR";
generate_files_list > "${OUTPUT_FILE}" || return 1;
echo "${OUTPUT_FILE} generated successfully.";
