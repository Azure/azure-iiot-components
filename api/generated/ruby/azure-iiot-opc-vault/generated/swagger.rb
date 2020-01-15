# encoding: utf-8
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.

require 'uri'
require 'cgi'
require 'date'
require 'json'
require 'base64'
require 'erb'
require 'securerandom'
require 'time'
require 'timeliness'
require 'faraday'
require 'faraday-cookie_jar'
require 'concurrent'
require 'ms_rest'
require 'generated/swagger/module_definition'

module azure.iiot.opc.vault
  autoload :AzureOpcVaultClient,                                'generated/swagger/azure_opc_vault_client.rb'

  module Models
    autoload :StartNewKeyPairRequestResponseApiModel,             'generated/swagger/models/start_new_key_pair_request_response_api_model.rb'
    autoload :PrivateKeyApiModel,                                 'generated/swagger/models/private_key_api_model.rb'
    autoload :X509CertificateChainApiModel,                       'generated/swagger/models/x509certificate_chain_api_model.rb'
    autoload :FinishNewKeyPairRequestResponseApiModel,            'generated/swagger/models/finish_new_key_pair_request_response_api_model.rb'
    autoload :X509CrlChainApiModel,                               'generated/swagger/models/x509crl_chain_api_model.rb'
    autoload :CertificateRequestQueryRequestApiModel,             'generated/swagger/models/certificate_request_query_request_api_model.rb'
    autoload :StartSigningRequestApiModel,                        'generated/swagger/models/start_signing_request_api_model.rb'
    autoload :CertificateRequestQueryResponseApiModel,            'generated/swagger/models/certificate_request_query_response_api_model.rb'
    autoload :VaultOperationContextApiModel,                      'generated/swagger/models/vault_operation_context_api_model.rb'
    autoload :TrustGroupApiModel,                                 'generated/swagger/models/trust_group_api_model.rb'
    autoload :FinishSigningRequestResponseApiModel,               'generated/swagger/models/finish_signing_request_response_api_model.rb'
    autoload :TrustGroupRegistrationApiModel,                     'generated/swagger/models/trust_group_registration_api_model.rb'
    autoload :X509CertificateApiModel,                            'generated/swagger/models/x509certificate_api_model.rb'
    autoload :TrustGroupRegistrationListApiModel,                 'generated/swagger/models/trust_group_registration_list_api_model.rb'
    autoload :NotFoundResult,                                     'generated/swagger/models/not_found_result.rb'
    autoload :TrustGroupRegistrationRequestApiModel,              'generated/swagger/models/trust_group_registration_request_api_model.rb'
    autoload :CertificateRequestRecordApiModel,                   'generated/swagger/models/certificate_request_record_api_model.rb'
    autoload :TrustGroupRegistrationResponseApiModel,             'generated/swagger/models/trust_group_registration_response_api_model.rb'
    autoload :X509CrlApiModel,                                    'generated/swagger/models/x509crl_api_model.rb'
    autoload :TrustGroupUpdateRequestApiModel,                    'generated/swagger/models/trust_group_update_request_api_model.rb'
    autoload :StartNewKeyPairRequestApiModel,                     'generated/swagger/models/start_new_key_pair_request_api_model.rb'
    autoload :TrustGroupRootCreateRequestApiModel,                'generated/swagger/models/trust_group_root_create_request_api_model.rb'
    autoload :StartSigningRequestResponseApiModel,                'generated/swagger/models/start_signing_request_response_api_model.rb'
    autoload :X509CertificateListApiModel,                        'generated/swagger/models/x509certificate_list_api_model.rb'
    autoload :CertificateRequestState,                            'generated/swagger/models/certificate_request_state.rb'
    autoload :CertificateRequestType,                             'generated/swagger/models/certificate_request_type.rb'
    autoload :TrustGroupType,                                     'generated/swagger/models/trust_group_type.rb'
    autoload :PrivateKeyType,                                     'generated/swagger/models/private_key_type.rb'
    autoload :SignatureAlgorithm,                                 'generated/swagger/models/signature_algorithm.rb'
  end
end
