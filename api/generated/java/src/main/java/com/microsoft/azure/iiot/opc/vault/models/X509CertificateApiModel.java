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

import org.joda.time.DateTime;
import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Certificate model.
 */
public class X509CertificateApiModel {
    /**
     * Subject.
     */
    @JsonProperty(value = "subject")
    private String subject;

    /**
     * Thumbprint.
     */
    @JsonProperty(value = "thumbprint")
    private String thumbprint;

    /**
     * Serial number.
     */
    @JsonProperty(value = "serialNumber")
    private String serialNumber;

    /**
     * Not before validity.
     */
    @JsonProperty(value = "notBeforeUtc")
    private DateTime notBeforeUtc;

    /**
     * Not after validity.
     */
    @JsonProperty(value = "notAfterUtc")
    private DateTime notAfterUtc;

    /**
     * Raw data.
     */
    @JsonProperty(value = "certificate", required = true)
    private Object certificate;

    /**
     * Get subject.
     *
     * @return the subject value
     */
    public String subject() {
        return this.subject;
    }

    /**
     * Set subject.
     *
     * @param subject the subject value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withSubject(String subject) {
        this.subject = subject;
        return this;
    }

    /**
     * Get thumbprint.
     *
     * @return the thumbprint value
     */
    public String thumbprint() {
        return this.thumbprint;
    }

    /**
     * Set thumbprint.
     *
     * @param thumbprint the thumbprint value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withThumbprint(String thumbprint) {
        this.thumbprint = thumbprint;
        return this;
    }

    /**
     * Get serial number.
     *
     * @return the serialNumber value
     */
    public String serialNumber() {
        return this.serialNumber;
    }

    /**
     * Set serial number.
     *
     * @param serialNumber the serialNumber value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withSerialNumber(String serialNumber) {
        this.serialNumber = serialNumber;
        return this;
    }

    /**
     * Get not before validity.
     *
     * @return the notBeforeUtc value
     */
    public DateTime notBeforeUtc() {
        return this.notBeforeUtc;
    }

    /**
     * Set not before validity.
     *
     * @param notBeforeUtc the notBeforeUtc value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withNotBeforeUtc(DateTime notBeforeUtc) {
        this.notBeforeUtc = notBeforeUtc;
        return this;
    }

    /**
     * Get not after validity.
     *
     * @return the notAfterUtc value
     */
    public DateTime notAfterUtc() {
        return this.notAfterUtc;
    }

    /**
     * Set not after validity.
     *
     * @param notAfterUtc the notAfterUtc value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withNotAfterUtc(DateTime notAfterUtc) {
        this.notAfterUtc = notAfterUtc;
        return this;
    }

    /**
     * Get raw data.
     *
     * @return the certificate value
     */
    public Object certificate() {
        return this.certificate;
    }

    /**
     * Set raw data.
     *
     * @param certificate the certificate value to set
     * @return the X509CertificateApiModel object itself.
     */
    public X509CertificateApiModel withCertificate(Object certificate) {
        this.certificate = certificate;
        return this;
    }

}
