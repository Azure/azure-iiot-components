/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

'use strict';

/**
 * Gateway modules model
 *
 */
class GatewayModulesApiModel {
  /**
   * Create a GatewayModulesApiModel.
   * @property {object} [supervisor]
   * @property {string} [supervisor.id] Supervisor id
   * @property {string} [supervisor.siteId] Site of the supervisor
   * @property {buffer} [supervisor.certificate] Supervisor public client cert
   * @property {string} [supervisor.logLevel] Possible values include: 'Error',
   * 'Information', 'Debug', 'Verbose'
   * @property {boolean} [supervisor.outOfSync] Whether the registration is out
   * of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [supervisor.connected] Whether supervisor is connected
   * on this registration
   * @property {object} [publisher]
   * @property {string} [publisher.id] Publisher id
   * @property {string} [publisher.siteId] Site of the publisher
   * @property {buffer} [publisher.certificate] Publisher public client cert
   * @property {string} [publisher.logLevel] Possible values include: 'Error',
   * 'Information', 'Debug', 'Verbose'
   * @property {object} [publisher.configuration]
   * @property {object} [publisher.configuration.capabilities] Capabilities
   * @property {string} [publisher.configuration.jobCheckInterval] Interval to
   * check job
   * @property {string} [publisher.configuration.heartbeatInterval] Heartbeat
   * interval
   * @property {number} [publisher.configuration.maxWorkers] Parallel jobs
   * @property {string} [publisher.configuration.jobOrchestratorUrl] Job
   * orchestrator endpoint url
   * @property {boolean} [publisher.outOfSync] Whether the registration is out
   * of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [publisher.connected] Whether publisher is connected
   * on this registration
   * @property {object} [discoverer]
   * @property {string} [discoverer.id] Discoverer id
   * @property {string} [discoverer.siteId] Site of the discoverer
   * @property {string} [discoverer.discovery] Possible values include: 'Off',
   * 'Local', 'Network', 'Fast', 'Scan'
   * @property {object} [discoverer.discoveryConfig]
   * @property {string} [discoverer.discoveryConfig.addressRangesToScan]
   * Address ranges to scan (null == all wired nics)
   * @property {number} [discoverer.discoveryConfig.networkProbeTimeoutMs]
   * Network probe timeout
   * @property {number} [discoverer.discoveryConfig.maxNetworkProbes] Max
   * network probes that should ever run.
   * @property {string} [discoverer.discoveryConfig.portRangesToScan] Port
   * ranges to scan (null == all unassigned)
   * @property {number} [discoverer.discoveryConfig.portProbeTimeoutMs] Port
   * probe timeout
   * @property {number} [discoverer.discoveryConfig.maxPortProbes] Max port
   * probes that should ever run.
   * @property {number} [discoverer.discoveryConfig.minPortProbesPercent]
   * Probes that must always be there as percent of max.
   * @property {number} [discoverer.discoveryConfig.idleTimeBetweenScansSec]
   * Delay time between discovery sweeps in seconds
   * @property {array} [discoverer.discoveryConfig.discoveryUrls] List of
   * preset discovery urls to use
   * @property {array} [discoverer.discoveryConfig.locales] List of locales to
   * filter with during discovery
   * @property {object} [discoverer.discoveryConfig.activationFilter]
   * @property {array} [discoverer.discoveryConfig.activationFilter.trustLists]
   * Certificate trust list identifiers to use for
   * activation, if null, all certificates are
   * trusted.  If empty list, no certificates are
   * trusted which is equal to no filter.
   * @property {array}
   * [discoverer.discoveryConfig.activationFilter.securityPolicies] Endpoint
   * security policies to filter against.
   * If set to null, all policies are in scope.
   * @property {string}
   * [discoverer.discoveryConfig.activationFilter.securityMode] Possible values
   * include: 'Best', 'Sign', 'SignAndEncrypt', 'None'
   * @property {string} [discoverer.logLevel] Possible values include: 'Error',
   * 'Information', 'Debug', 'Verbose'
   * @property {boolean} [discoverer.outOfSync] Whether the registration is out
   * of sync between
   * client (module) and server (service) (default: false).
   * @property {boolean} [discoverer.connected] Whether discoverer is connected
   * on this registration
   */
  constructor() {
  }

  /**
   * Defines the metadata of GatewayModulesApiModel
   *
   * @returns {object} metadata of GatewayModulesApiModel
   *
   */
  mapper() {
    return {
      required: false,
      serializedName: 'GatewayModulesApiModel',
      type: {
        name: 'Composite',
        className: 'GatewayModulesApiModel',
        modelProperties: {
          supervisor: {
            required: false,
            serializedName: 'supervisor',
            type: {
              name: 'Composite',
              className: 'SupervisorApiModel'
            }
          },
          publisher: {
            required: false,
            serializedName: 'publisher',
            type: {
              name: 'Composite',
              className: 'PublisherApiModel'
            }
          },
          discoverer: {
            required: false,
            serializedName: 'discoverer',
            type: {
              name: 'Composite',
              className: 'DiscovererApiModel'
            }
          }
        }
      }
    };
  }
}

module.exports = GatewayModulesApiModel;
