# encoding: utf-8
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.

module azure.iiot.opc.registry
  module Models
    #
    # Endpoint registration model
    #
    class EndpointRegistrationApiModel
      # @return [String] Registered identifier of the endpoint
      attr_accessor :id

      # @return [String] Original endpoint url of the endpoint
      attr_accessor :endpoint_url

      # @return [String] Registered site of the endpoint
      attr_accessor :site_id

      # @return [EndpointApiModel] Endpoint information of the registration
      attr_accessor :endpoint

      # @return [Integer] Security level of the endpoint
      attr_accessor :security_level

      # @return [Array<AuthenticationMethodApiModel>] Supported authentication
      # methods that can be selected to
      # obtain a credential and used to interact with the endpoint.
      attr_accessor :authentication_methods


      #
      # Mapper for EndpointRegistrationApiModel class as Ruby Hash.
      # This will be used for serialization/deserialization.
      #
      def self.mapper()
        {
          client_side_validation: true,
          required: false,
          serialized_name: 'EndpointRegistrationApiModel',
          type: {
            name: 'Composite',
            class_name: 'EndpointRegistrationApiModel',
            model_properties: {
              id: {
                client_side_validation: true,
                required: true,
                serialized_name: 'id',
                type: {
                  name: 'String'
                }
              },
              endpoint_url: {
                client_side_validation: true,
                required: false,
                serialized_name: 'endpointUrl',
                type: {
                  name: 'String'
                }
              },
              site_id: {
                client_side_validation: true,
                required: false,
                serialized_name: 'siteId',
                type: {
                  name: 'String'
                }
              },
              endpoint: {
                client_side_validation: true,
                required: true,
                serialized_name: 'endpoint',
                type: {
                  name: 'Composite',
                  class_name: 'EndpointApiModel'
                }
              },
              security_level: {
                client_side_validation: true,
                required: false,
                serialized_name: 'securityLevel',
                type: {
                  name: 'Number'
                }
              },
              authentication_methods: {
                client_side_validation: true,
                required: false,
                serialized_name: 'authenticationMethods',
                type: {
                  name: 'Sequence',
                  element: {
                      client_side_validation: true,
                      required: false,
                      serialized_name: 'AuthenticationMethodApiModelElementType',
                      type: {
                        name: 'Composite',
                        class_name: 'AuthenticationMethodApiModel'
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
