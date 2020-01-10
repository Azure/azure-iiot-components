# coding=utf-8
# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
#
# Code generated by Microsoft (R) AutoRest Code Generator 2.3.33.0
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.
# --------------------------------------------------------------------------

from msrest.serialization import Model


class TrustGroupApiModel(Model):
    """Trust group model.

    :param name: The name of the trust group.
    :type name: str
    :param parent_id: The identifer of the parent trust group.
    :type parent_id: str
    :param type: Possible values include: 'ApplicationInstanceCertificate',
     'HttpsCertificate', 'UserCredentialCertificate'
    :type type: str or ~azure-iiot-opc-vault.models.TrustGroupType
    :param subject_name: The subject name of the group as distinguished name.
    :type subject_name: str
    :param lifetime: The lifetime of the trust group certificate.
    :type lifetime: str
    :param key_size: The trust group certificate key size in bits.
    :type key_size: int
    :param signature_algorithm: Possible values include: 'Rsa256', 'Rsa384',
     'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'
    :type signature_algorithm: str or
     ~azure-iiot-opc-vault.models.SignatureAlgorithm
    :param issued_lifetime: The issued certificate lifetime in months.
    :type issued_lifetime: str
    :param issued_key_size: The issued certificate key size in bits.
    :type issued_key_size: int
    :param issued_signature_algorithm: Possible values include: 'Rsa256',
     'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'
    :type issued_signature_algorithm: str or
     ~azure-iiot-opc-vault.models.SignatureAlgorithm
    """

    _validation = {
        'name': {'required': True},
        'subject_name': {'required': True},
    }

    _attribute_map = {
        'name': {'key': 'name', 'type': 'str'},
        'parent_id': {'key': 'parentId', 'type': 'str'},
        'type': {'key': 'type', 'type': 'TrustGroupType'},
        'subject_name': {'key': 'subjectName', 'type': 'str'},
        'lifetime': {'key': 'lifetime', 'type': 'str'},
        'key_size': {'key': 'keySize', 'type': 'int'},
        'signature_algorithm': {'key': 'signatureAlgorithm', 'type': 'SignatureAlgorithm'},
        'issued_lifetime': {'key': 'issuedLifetime', 'type': 'str'},
        'issued_key_size': {'key': 'issuedKeySize', 'type': 'int'},
        'issued_signature_algorithm': {'key': 'issuedSignatureAlgorithm', 'type': 'SignatureAlgorithm'},
    }

    def __init__(self, name, subject_name, parent_id=None, type=None, lifetime=None, key_size=None, signature_algorithm=None, issued_lifetime=None, issued_key_size=None, issued_signature_algorithm=None):
        super(TrustGroupApiModel, self).__init__()
        self.name = name
        self.parent_id = parent_id
        self.type = type
        self.subject_name = subject_name
        self.lifetime = lifetime
        self.key_size = key_size
        self.signature_algorithm = signature_algorithm
        self.issued_lifetime = issued_lifetime
        self.issued_key_size = issued_key_size
        self.issued_signature_algorithm = issued_signature_algorithm
