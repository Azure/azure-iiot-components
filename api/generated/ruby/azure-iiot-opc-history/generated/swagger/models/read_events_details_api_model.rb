# encoding: utf-8
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.

module azure.iiot.opc.history
  module Models
    #
    # Read event data
    #
    class ReadEventsDetailsApiModel
      # @return [DateTime] Start time to read from
      attr_accessor :start_time

      # @return [DateTime] End time to read to
      attr_accessor :end_time

      # @return [Integer] Number of events to read
      attr_accessor :num_events

      # @return The filter to use to select the event fields
      attr_accessor :filter


      #
      # Mapper for ReadEventsDetailsApiModel class as Ruby Hash.
      # This will be used for serialization/deserialization.
      #
      def self.mapper()
        {
          client_side_validation: true,
          required: false,
          serialized_name: 'ReadEventsDetailsApiModel',
          type: {
            name: 'Composite',
            class_name: 'ReadEventsDetailsApiModel',
            model_properties: {
              start_time: {
                client_side_validation: true,
                required: false,
                serialized_name: 'startTime',
                type: {
                  name: 'DateTime'
                }
              },
              end_time: {
                client_side_validation: true,
                required: false,
                serialized_name: 'endTime',
                type: {
                  name: 'DateTime'
                }
              },
              num_events: {
                client_side_validation: true,
                required: false,
                serialized_name: 'numEvents',
                type: {
                  name: 'Number'
                }
              },
              filter: {
                client_side_validation: true,
                required: false,
                serialized_name: 'filter',
                type: {
                  name: 'Object'
                }
              }
            }
          }
        }
      end
    end
  end
end
