## This file contains functions for calling the Unity3D build process from cmake
##
## @author Daniel J. Finnegan
## @date July 2018

find_package (
    UnityGame
    2018.1
#   EXACT # Use this to indicate you only want to work with the given version of Unity
    REQUIRED
)

## Create a unity project
function (
    create_unity_project
    project_path
)

    if (NOT DEFINED UNITY_PROJECT_CREATED OR (NOT UNITY_PROJECT_CREATED) )

        message (
            STATUS
            "Creating ${ARGV0}..."
        )

        execute_process (
            COMMAND
                ${UnityGame_EXECUTABLE}
                -quit
                -batchmode
                -createProject ${CMAKE_SOURCE_DIR}/Unity
        )

        set (
            UNITY_PROJECT_CREATED
            ON
            CACHE
            BOOL
            "Is the Unity Project Instantiated?"
            FORCE
        )

    endif ()

endfunction()

## Simply call Unity to install the package
function (
    install_unity_package
    package_name
    package_path
)

    message (
        STATUS
#        "Importing the ${ARGV0} package into the unity project..."
        "Importing ${ARGV1} into ${CMAKE_SOURCE_DIR}/unity"
    )

    # Use Unity's powerful command line interface to automatically import the package

    execute_process (
        COMMAND
            ${UnityGame_EXECUTABLE}
            -quit
#            -batchmode # Running this out of batchmode seems to fix the import bug
            -projectPath ${CMAKE_SOURCE_DIR}/unity
            -importPackage ${ARGV1}
    )

endfunction ()