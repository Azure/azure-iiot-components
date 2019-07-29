/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package com.microsoft.azure.iiot.opc.vault.models;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Trust group root registration model.
 */
public class TrustGroupRootCreateRequestApiModel {
    /**
     * The new name of the trust group root.
     */
    @JsonProperty(value = "name", required = true)
    private String name;

    /**
     * The trust group type. Possible values include:
     * 'ApplicationInstanceCertificate', 'HttpsCertificate',
     * 'UserCredentialCertificate'.
     */
    @JsonProperty(value = "type")
    private TrustGroupType type;

    /**
     * The subject name of the group as distinguished name.
     */
    @JsonProperty(value = "subjectName", required = true)
    private String subjectName;

    /**
     * The lifetime of the trust group root certificate.
     */
    @JsonProperty(value = "lifetime", required = true)
    private String lifetime;

    /**
     * The certificate key size in bits.
     */
    @JsonProperty(value = "keySize")
    private Integer keySize;

    /**
     * The certificate signature algorithm. Possible values include: 'Rsa256',
     * 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     */
    @JsonProperty(value = "signatureAlgorithm")
    private SignatureAlgorithm signatureAlgorithm;

    /**
     * The issued certificate lifetime.
     */
    @JsonProperty(value = "issuedLifetime")
    private String issuedLifetime;

    /**
     * The issued certificate key size in bits.
     */
    @JsonProperty(value = "issuedKeySize")
    private Integer issuedKeySize;

    /**
     * The issued certificate signature algorithm. Possible values include:
     * 'Rsa256', 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     */
    @JsonProperty(value = "issuedSignatureAlgorithm")
    private SignatureAlgorithm issuedSignatureAlgorithm;

    /**
     * Get the new name of the trust group root.
     *
     * @return the name value
     */
    public String name() {
        return this.name;
    }

    /**
     * Set the new name of the trust group root.
     *
     * @param name the name value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withName(String name) {
        this.name = name;
        return this;
    }

    /**
     * Get the trust group type. Possible values include: 'ApplicationInstanceCertificate', 'HttpsCertificate', 'UserCredentialCertificate'.
     *
     * @return the type value
     */
    public TrustGroupType type() {
        return this.type;
    }

    /**
     * Set the trust group type. Possible values include: 'ApplicationInstanceCertificate', 'HttpsCertificate', 'UserCredentialCertificate'.
     *
     * @param type the type value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withType(TrustGroupType type) {
        this.type = type;
        return this;
    }

    /**
     * Get the subject name of the group as distinguished name.
     *
     * @return the subjectName value
     */
    public String subjectName() {
        return this.subjectName;
    }

    /**
     * Set the subject name of the group as distinguished name.
     *
     * @param subjectName the subjectName value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withSubjectName(String subjectName) {
        this.subjectName = subjectName;
        return this;
    }

    /**
     * Get the lifetime of the trust group root certificate.
     *
     * @return the lifetime value
     */
    public String lifetime() {
        return this.lifetime;
    }

    /**
     * Set the lifetime of the trust group root certificate.
     *
     * @param lifetime the lifetime value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withLifetime(String lifetime) {
        this.lifetime = lifetime;
        return this;
    }

    /**
     * Get the certificate key size in bits.
     *
     * @return the keySize value
     */
    public Integer keySize() {
        return this.keySize;
    }

    /**
     * Set the certificate key size in bits.
     *
     * @param keySize the keySize value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withKeySize(Integer keySize) {
        this.keySize = keySize;
        return this;
    }

    /**
     * Get the certificate signature algorithm. Possible values include: 'Rsa256', 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     *
     * @return the signatureAlgorithm value
     */
    public SignatureAlgorithm signatureAlgorithm() {
        return this.signatureAlgorithm;
    }

    /**
     * Set the certificate signature algorithm. Possible values include: 'Rsa256', 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     *
     * @param signatureAlgorithm the signatureAlgorithm value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withSignatureAlgorithm(SignatureAlgorithm signatureAlgorithm) {
        this.signatureAlgorithm = signatureAlgorithm;
        return this;
    }

    /**
     * Get the issued certificate lifetime.
     *
     * @return the issuedLifetime value
     */
    public String issuedLifetime() {
        return this.issuedLifetime;
    }

    /**
     * Set the issued certificate lifetime.
     *
     * @param issuedLifetime the issuedLifetime value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withIssuedLifetime(String issuedLifetime) {
        this.issuedLifetime = issuedLifetime;
        return this;
    }

    /**
     * Get the issued certificate key size in bits.
     *
     * @return the issuedKeySize value
     */
    public Integer issuedKeySize() {
        return this.issuedKeySize;
    }

    /**
     * Set the issued certificate key size in bits.
     *
     * @param issuedKeySize the issuedKeySize value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withIssuedKeySize(Integer issuedKeySize) {
        this.issuedKeySize = issuedKeySize;
        return this;
    }

    /**
     * Get the issued certificate signature algorithm. Possible values include: 'Rsa256', 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     *
     * @return the issuedSignatureAlgorithm value
     */
    public SignatureAlgorithm issuedSignatureAlgorithm() {
        return this.issuedSignatureAlgorithm;
    }

    /**
     * Set the issued certificate signature algorithm. Possible values include: 'Rsa256', 'Rsa384', 'Rsa512', 'Rsa256Pss', 'Rsa384Pss', 'Rsa512Pss'.
     *
     * @param issuedSignatureAlgorithm the issuedSignatureAlgorithm value to set
     * @return the TrustGroupRootCreateRequestApiModel object itself.
     */
    public TrustGroupRootCreateRequestApiModel withIssuedSignatureAlgorithm(SignatureAlgorithm issuedSignatureAlgorithm) {
        this.issuedSignatureAlgorithm = issuedSignatureAlgorithm;
        return this;
    }

}
