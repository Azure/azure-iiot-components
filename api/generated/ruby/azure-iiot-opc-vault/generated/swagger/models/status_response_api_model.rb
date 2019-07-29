# encoding: utf-8
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.

module azure.iiot.opc.vault
  module Models
    #
    # Status model
    #
    class StatusResponseApiModel
      # @return [String] Service name
      attr_accessor :name

      # @return [String] Status
      attr_accessor :status

      # @return [String] Current time
      attr_accessor :current_time

      # @return [String] Service start time
      attr_accessor :start_time

      # @return [Integer] Uptime
      attr_accessor :up_time

      # @return [String] Value generated at bootstrap by each instance of the
      # service and
      # used to correlate logs coming from the same instance. The value
      # changes every time the service starts.
      attr_accessor :uid

      # @return [Hash{String => String}] A property bag with details about the
      # service
      attr_accessor :properties

      # @return [Hash{String => String}] A property bag with details about the
      # internal dependencies
      attr_accessor :dependencies

      # @return [Hash{String => String}] Meta data
      attr_accessor :metadata


      #
      # Mapper for StatusResponseApiModel class as Ruby Hash.
      # This will be used for serialization/deserialization.
      #
      def self.mapper()
        {
          client_side_validation: true,
          required: false,
          serialized_name: 'StatusResponseApiModel',
          type: {
            name: 'Composite',
            class_name: 'StatusResponseApiModel',
            model_properties: {
              name: {
                client_side_validation: true,
                required: false,
                serialized_name: 'name',
                type: {
                  name: 'String'
                }
              },
              status: {
                client_side_validation: true,
                required: false,
                serialized_name: 'status',
                type: {
                  name: 'String'
                }
              },
              current_time: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'currentTime',
                type: {
                  name: 'String'
                }
              },
              start_time: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'startTime',
                type: {
                  name: 'String'
                }
              },
              up_time: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'upTime',
                type: {
                  name: 'Number'
                }
              },
              uid: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'uid',
                type: {
                  name: 'String'
                }
              },
              properties: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'properties',
                type: {
                  name: 'Dictionary',
                  value: {
                      client_side_validation: true,
                      required: false,
                      serialized_name: 'StringElementType',
                      type: {
                        name: 'String'
                      }
                  }
                }
              },
              dependencies: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: 'dependencies',
                type: {
                  name: 'Dictionary',
                  value: {
                      client_side_validation: true,
                      required: false,
                      serialized_name: 'StringElementType',
                      type: {
                        name: 'String'
                      }
                  }
                }
              },
              metadata: {
                client_side_validation: true,
                required: false,
                read_only: true,
                serialized_name: '$metadata',
                type: {
                  name: 'Dictionary',
                  value: {
                      client_side_validation: true,
                      required: false,
                      serialized_name: 'StringElementType',
                      type: {
                        name: 'String'
                      }
                  }
                }
              }
            }
          }
        }
      end
    end
  end
end
