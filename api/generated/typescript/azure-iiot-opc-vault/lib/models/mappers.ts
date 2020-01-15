/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";


export const X509CertificateApiModel: msRest.CompositeMapper = {
  serializedName: "X509CertificateApiModel",
  type: {
    name: "Composite",
    className: "X509CertificateApiModel",
    modelProperties: {
      subject: {
        serializedName: "subject",
        type: {
          name: "String"
        }
      },
      thumbprint: {
        serializedName: "thumbprint",
        type: {
          name: "String"
        }
      },
      serialNumber: {
        serializedName: "serialNumber",
        type: {
          name: "String"
        }
      },
      notBeforeUtc: {
        serializedName: "notBeforeUtc",
        type: {
          name: "DateTime"
        }
      },
      notAfterUtc: {
        serializedName: "notAfterUtc",
        type: {
          name: "DateTime"
        }
      },
      certificate: {
        serializedName: "certificate",
        type: {
          name: "Object"
        }
      }
    }
  }
};

export const X509CertificateChainApiModel: msRest.CompositeMapper = {
  serializedName: "X509CertificateChainApiModel",
  type: {
    name: "Composite",
    className: "X509CertificateChainApiModel",
    modelProperties: {
      chain: {
        serializedName: "chain",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "X509CertificateApiModel"
            }
          }
        }
      }
    }
  }
};

export const X509CrlApiModel: msRest.CompositeMapper = {
  serializedName: "X509CrlApiModel",
  type: {
    name: "Composite",
    className: "X509CrlApiModel",
    modelProperties: {
      issuer: {
        serializedName: "issuer",
        type: {
          name: "String"
        }
      },
      crl: {
        serializedName: "crl",
        type: {
          name: "Object"
        }
      }
    }
  }
};

export const X509CrlChainApiModel: msRest.CompositeMapper = {
  serializedName: "X509CrlChainApiModel",
  type: {
    name: "Composite",
    className: "X509CrlChainApiModel",
    modelProperties: {
      chain: {
        serializedName: "chain",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "X509CrlApiModel"
            }
          }
        }
      }
    }
  }
};

export const NotFoundResult: msRest.CompositeMapper = {
  serializedName: "NotFoundResult",
  type: {
    name: "Composite",
    className: "NotFoundResult",
    modelProperties: {
      statusCode: {
        readOnly: true,
        serializedName: "statusCode",
        type: {
          name: "Number"
        }
      }
    }
  }
};

export const StartSigningRequestApiModel: msRest.CompositeMapper = {
  serializedName: "StartSigningRequestApiModel",
  type: {
    name: "Composite",
    className: "StartSigningRequestApiModel",
    modelProperties: {
      entityId: {
        serializedName: "entityId",
        type: {
          name: "String"
        }
      },
      groupId: {
        serializedName: "groupId",
        type: {
          name: "String"
        }
      },
      certificateRequest: {
        serializedName: "certificateRequest",
        type: {
          name: "Object"
        }
      }
    }
  }
};

export const StartSigningRequestResponseApiModel: msRest.CompositeMapper = {
  serializedName: "StartSigningRequestResponseApiModel",
  type: {
    name: "Composite",
    className: "StartSigningRequestResponseApiModel",
    modelProperties: {
      requestId: {
        serializedName: "requestId",
        type: {
          name: "String"
        }
      }
    }
  }
};

export const VaultOperationContextApiModel: msRest.CompositeMapper = {
  serializedName: "VaultOperationContextApiModel",
  type: {
    name: "Composite",
    className: "VaultOperationContextApiModel",
    modelProperties: {
      authorityId: {
        serializedName: "authorityId",
        type: {
          name: "String"
        }
      },
      time: {
        serializedName: "time",
        type: {
          name: "DateTime"
        }
      }
    }
  }
};

export const CertificateRequestRecordApiModel: msRest.CompositeMapper = {
  serializedName: "CertificateRequestRecordApiModel",
  type: {
    name: "Composite",
    className: "CertificateRequestRecordApiModel",
    modelProperties: {
      requestId: {
        serializedName: "requestId",
        type: {
          name: "String"
        }
      },
      entityId: {
        serializedName: "entityId",
        type: {
          name: "String"
        }
      },
      groupId: {
        serializedName: "groupId",
        type: {
          name: "String"
        }
      },
      state: {
        serializedName: "state",
        type: {
          name: "Enum",
          allowedValues: [
            "New",
            "Approved",
            "Rejected",
            "Failure",
            "Completed",
            "Accepted"
          ]
        }
      },
      type: {
        serializedName: "type",
        type: {
          name: "Enum",
          allowedValues: [
            "SigningRequest",
            "KeyPairRequest"
          ]
        }
      },
      errorInfo: {
        serializedName: "errorInfo",
        type: {
          name: "Object"
        }
      },
      submitted: {
        serializedName: "submitted",
        type: {
          name: "Composite",
          className: "VaultOperationContextApiModel"
        }
      },
      approved: {
        serializedName: "approved",
        type: {
          name: "Composite",
          className: "VaultOperationContextApiModel"
        }
      },
      accepted: {
        serializedName: "accepted",
        type: {
          name: "Composite",
          className: "VaultOperationContextApiModel"
        }
      }
    }
  }
};

export const FinishSigningRequestResponseApiModel: msRest.CompositeMapper = {
  serializedName: "FinishSigningRequestResponseApiModel",
  type: {
    name: "Composite",
    className: "FinishSigningRequestResponseApiModel",
    modelProperties: {
      request: {
        serializedName: "request",
        type: {
          name: "Composite",
          className: "CertificateRequestRecordApiModel"
        }
      },
      certificate: {
        serializedName: "certificate",
        type: {
          name: "Composite",
          className: "X509CertificateApiModel"
        }
      }
    }
  }
};

export const StartNewKeyPairRequestApiModel: msRest.CompositeMapper = {
  serializedName: "StartNewKeyPairRequestApiModel",
  type: {
    name: "Composite",
    className: "StartNewKeyPairRequestApiModel",
    modelProperties: {
      entityId: {
        serializedName: "entityId",
        type: {
          name: "String"
        }
      },
      groupId: {
        serializedName: "groupId",
        type: {
          name: "String"
        }
      },
      certificateType: {
        serializedName: "certificateType",
        type: {
          name: "Enum",
          allowedValues: [
            "ApplicationInstanceCertificate",
            "HttpsCertificate",
            "UserCredentialCertificate"
          ]
        }
      },
      subjectName: {
        serializedName: "subjectName",
        type: {
          name: "String"
        }
      },
      domainNames: {
        serializedName: "domainNames",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "String"
            }
          }
        }
      }
    }
  }
};

export const StartNewKeyPairRequestResponseApiModel: msRest.CompositeMapper = {
  serializedName: "StartNewKeyPairRequestResponseApiModel",
  type: {
    name: "Composite",
    className: "StartNewKeyPairRequestResponseApiModel",
    modelProperties: {
      requestId: {
        serializedName: "requestId",
        type: {
          name: "String"
        }
      }
    }
  }
};

export const PrivateKeyApiModel: msRest.CompositeMapper = {
  serializedName: "PrivateKeyApiModel",
  type: {
    name: "Composite",
    className: "PrivateKeyApiModel",
    modelProperties: {
      kty: {
        serializedName: "kty",
        type: {
          name: "Enum",
          allowedValues: [
            "RSA",
            "ECC",
            "AES"
          ]
        }
      },
      n: {
        serializedName: "n",
        type: {
          name: "ByteArray"
        }
      },
      e: {
        serializedName: "e",
        type: {
          name: "ByteArray"
        }
      },
      dp: {
        serializedName: "dp",
        type: {
          name: "ByteArray"
        }
      },
      dq: {
        serializedName: "dq",
        type: {
          name: "ByteArray"
        }
      },
      qi: {
        serializedName: "qi",
        type: {
          name: "ByteArray"
        }
      },
      p: {
        serializedName: "p",
        type: {
          name: "ByteArray"
        }
      },
      q: {
        serializedName: "q",
        type: {
          name: "ByteArray"
        }
      },
      crv: {
        serializedName: "crv",
        type: {
          name: "String"
        }
      },
      x: {
        serializedName: "x",
        type: {
          name: "ByteArray"
        }
      },
      y: {
        serializedName: "y",
        type: {
          name: "ByteArray"
        }
      },
      d: {
        serializedName: "d",
        type: {
          name: "ByteArray"
        }
      },
      k: {
        serializedName: "k",
        type: {
          name: "ByteArray"
        }
      },
      keyHsm: {
        serializedName: "key_hsm",
        type: {
          name: "ByteArray"
        }
      }
    }
  }
};

export const FinishNewKeyPairRequestResponseApiModel: msRest.CompositeMapper = {
  serializedName: "FinishNewKeyPairRequestResponseApiModel",
  type: {
    name: "Composite",
    className: "FinishNewKeyPairRequestResponseApiModel",
    modelProperties: {
      request: {
        serializedName: "request",
        type: {
          name: "Composite",
          className: "CertificateRequestRecordApiModel"
        }
      },
      certificate: {
        serializedName: "certificate",
        type: {
          name: "Composite",
          className: "X509CertificateApiModel"
        }
      },
      privateKey: {
        serializedName: "privateKey",
        type: {
          name: "Composite",
          className: "PrivateKeyApiModel"
        }
      }
    }
  }
};

export const CertificateRequestQueryRequestApiModel: msRest.CompositeMapper = {
  serializedName: "CertificateRequestQueryRequestApiModel",
  type: {
    name: "Composite",
    className: "CertificateRequestQueryRequestApiModel",
    modelProperties: {
      entityId: {
        serializedName: "entityId",
        type: {
          name: "String"
        }
      },
      state: {
        serializedName: "state",
        type: {
          name: "Enum",
          allowedValues: [
            "New",
            "Approved",
            "Rejected",
            "Failure",
            "Completed",
            "Accepted"
          ]
        }
      }
    }
  }
};

export const CertificateRequestQueryResponseApiModel: msRest.CompositeMapper = {
  serializedName: "CertificateRequestQueryResponseApiModel",
  type: {
    name: "Composite",
    className: "CertificateRequestQueryResponseApiModel",
    modelProperties: {
      requests: {
        serializedName: "requests",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "CertificateRequestRecordApiModel"
            }
          }
        }
      },
      nextPageLink: {
        serializedName: "nextPageLink",
        type: {
          name: "String"
        }
      }
    }
  }
};

export const TrustGroupApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupApiModel",
    modelProperties: {
      name: {
        serializedName: "name",
        type: {
          name: "String"
        }
      },
      parentId: {
        serializedName: "parentId",
        type: {
          name: "String"
        }
      },
      type: {
        serializedName: "type",
        type: {
          name: "Enum",
          allowedValues: [
            "ApplicationInstanceCertificate",
            "HttpsCertificate",
            "UserCredentialCertificate"
          ]
        }
      },
      subjectName: {
        serializedName: "subjectName",
        type: {
          name: "String"
        }
      },
      lifetime: {
        serializedName: "lifetime",
        type: {
          name: "String"
        }
      },
      keySize: {
        serializedName: "keySize",
        type: {
          name: "Number"
        }
      },
      signatureAlgorithm: {
        serializedName: "signatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      },
      issuedLifetime: {
        serializedName: "issuedLifetime",
        type: {
          name: "String"
        }
      },
      issuedKeySize: {
        serializedName: "issuedKeySize",
        type: {
          name: "Number"
        }
      },
      issuedSignatureAlgorithm: {
        serializedName: "issuedSignatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      }
    }
  }
};

export const TrustGroupRegistrationApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupRegistrationApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupRegistrationApiModel",
    modelProperties: {
      id: {
        serializedName: "id",
        type: {
          name: "String"
        }
      },
      group: {
        serializedName: "group",
        type: {
          name: "Composite",
          className: "TrustGroupApiModel"
        }
      }
    }
  }
};

export const TrustGroupRegistrationListApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupRegistrationListApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupRegistrationListApiModel",
    modelProperties: {
      registrations: {
        serializedName: "registrations",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "TrustGroupRegistrationApiModel"
            }
          }
        }
      },
      nextPageLink: {
        serializedName: "nextPageLink",
        type: {
          name: "String"
        }
      }
    }
  }
};

export const TrustGroupRegistrationRequestApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupRegistrationRequestApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupRegistrationRequestApiModel",
    modelProperties: {
      name: {
        serializedName: "name",
        type: {
          name: "String"
        }
      },
      parentId: {
        serializedName: "parentId",
        type: {
          name: "String"
        }
      },
      subjectName: {
        serializedName: "subjectName",
        type: {
          name: "String"
        }
      },
      issuedLifetime: {
        serializedName: "issuedLifetime",
        type: {
          name: "String"
        }
      },
      issuedKeySize: {
        serializedName: "issuedKeySize",
        type: {
          name: "Number"
        }
      },
      issuedSignatureAlgorithm: {
        serializedName: "issuedSignatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      }
    }
  }
};

export const TrustGroupRegistrationResponseApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupRegistrationResponseApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupRegistrationResponseApiModel",
    modelProperties: {
      id: {
        serializedName: "id",
        type: {
          name: "String"
        }
      }
    }
  }
};

export const TrustGroupUpdateRequestApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupUpdateRequestApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupUpdateRequestApiModel",
    modelProperties: {
      name: {
        serializedName: "name",
        type: {
          name: "String"
        }
      },
      issuedLifetime: {
        serializedName: "issuedLifetime",
        type: {
          name: "String"
        }
      },
      issuedKeySize: {
        serializedName: "issuedKeySize",
        type: {
          name: "Number"
        }
      },
      issuedSignatureAlgorithm: {
        serializedName: "issuedSignatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      }
    }
  }
};

export const TrustGroupRootCreateRequestApiModel: msRest.CompositeMapper = {
  serializedName: "TrustGroupRootCreateRequestApiModel",
  type: {
    name: "Composite",
    className: "TrustGroupRootCreateRequestApiModel",
    modelProperties: {
      name: {
        serializedName: "name",
        type: {
          name: "String"
        }
      },
      type: {
        serializedName: "type",
        type: {
          name: "Enum",
          allowedValues: [
            "ApplicationInstanceCertificate",
            "HttpsCertificate",
            "UserCredentialCertificate"
          ]
        }
      },
      subjectName: {
        serializedName: "subjectName",
        type: {
          name: "String"
        }
      },
      lifetime: {
        serializedName: "lifetime",
        type: {
          name: "String"
        }
      },
      keySize: {
        serializedName: "keySize",
        type: {
          name: "Number"
        }
      },
      signatureAlgorithm: {
        serializedName: "signatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      },
      issuedLifetime: {
        serializedName: "issuedLifetime",
        type: {
          name: "String"
        }
      },
      issuedKeySize: {
        serializedName: "issuedKeySize",
        type: {
          name: "Number"
        }
      },
      issuedSignatureAlgorithm: {
        serializedName: "issuedSignatureAlgorithm",
        type: {
          name: "Enum",
          allowedValues: [
            "Rsa256",
            "Rsa384",
            "Rsa512",
            "Rsa256Pss",
            "Rsa384Pss",
            "Rsa512Pss"
          ]
        }
      }
    }
  }
};

export const X509CertificateListApiModel: msRest.CompositeMapper = {
  serializedName: "X509CertificateListApiModel",
  type: {
    name: "Composite",
    className: "X509CertificateListApiModel",
    modelProperties: {
      certificates: {
        serializedName: "certificates",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "X509CertificateApiModel"
            }
          }
        }
      },
      nextPageLink: {
        serializedName: "nextPageLink",
        type: {
          name: "String"
        }
      }
    }
  }
};
