# Copyright 2024 The Manifold Authors.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# https://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

include_directories(
  ${CMAKE_CURRENT_SOURCE_DIR}
  ${CMAKE_CURRENT_SOURCE_DIR}/include
  ${CMAKE_CURRENT_SOURCE_DIR}/../../include
)

add_library(
  manifoldc
  manifoldc.cpp
  conv.cpp
  box.cpp
  cross.cpp
  rect.cpp
)
exportlib(manifoldc)

target_link_libraries(manifoldc PRIVATE manifold)

target_include_directories(
  manifoldc
  PUBLIC
    $<INSTALL_INTERFACE:include>
    $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include>
)
target_compile_options(manifoldc PRIVATE ${MANIFOLD_FLAGS})

# iOS Framework creation
if(CMAKE_SYSTEM_NAME STREQUAL "iOS")
  set_target_properties(manifoldc PROPERTIES
    FRAMEWORK TRUE
    FRAMEWORK_VERSION A
    MACOSX_FRAMEWORK_IDENTIFIER org.manifold.manifoldc
    MACOSX_FRAMEWORK_INFO_PLIST "${CMAKE_CURRENT_SOURCE_DIR}/Info.plist"
    XCODE_ATTRIBUTE_IPHONEOS_DEPLOYMENT_TARGET "13.0"
    PUBLIC_HEADER "${CMAKE_CURRENT_SOURCE_DIR}/include/manifold/manifoldc.h;${CMAKE_CURRENT_SOURCE_DIR}/include/manifold/types.h"
  )
endif()

install(TARGETS manifoldc EXPORT manifoldTargets
  FRAMEWORK DESTINATION ${CMAKE_INSTALL_LIBDIR}
)
install(
  FILES include/manifold/manifoldc.h include/manifold/types.h
  DESTINATION ${CMAKE_INSTALL_INCLUDEDIR}/manifold
)
