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
 * Signing request.
 */
public class StartSigningRequestApiModel {
    /**
     * Id of entity to sign a certificate for.
     */
    @JsonProperty(value = "entityId", required = true)
    private String entityId;

    /**
     * Certificate group id.
     */
    @JsonProperty(value = "groupId", required = true)
    private String groupId;

    /**
     * Request.
     */
    @JsonProperty(value = "certificateRequest", required = true)
    private Object certificateRequest;

    /**
     * Get id of entity to sign a certificate for.
     *
     * @return the entityId value
     */
    public String entityId() {
        return this.entityId;
    }

    /**
     * Set id of entity to sign a certificate for.
     *
     * @param entityId the entityId value to set
     * @return the StartSigningRequestApiModel object itself.
     */
    public StartSigningRequestApiModel withEntityId(String entityId) {
        this.entityId = entityId;
        return this;
    }

    /**
     * Get certificate group id.
     *
     * @return the groupId value
     */
    public String groupId() {
        return this.groupId;
    }

    /**
     * Set certificate group id.
     *
     * @param groupId the groupId value to set
     * @return the StartSigningRequestApiModel object itself.
     */
    public StartSigningRequestApiModel withGroupId(String groupId) {
        this.groupId = groupId;
        return this;
    }

    /**
     * Get request.
     *
     * @return the certificateRequest value
     */
    public Object certificateRequest() {
        return this.certificateRequest;
    }

    /**
     * Set request.
     *
     * @param certificateRequest the certificateRequest value to set
     * @return the StartSigningRequestApiModel object itself.
     */
    public StartSigningRequestApiModel withCertificateRequest(Object certificateRequest) {
        this.certificateRequest = certificateRequest;
        return this;
    }

}
