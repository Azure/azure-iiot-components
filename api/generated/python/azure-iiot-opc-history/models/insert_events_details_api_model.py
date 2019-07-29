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


class InsertEventsDetailsApiModel(Model):
    """Insert historic events.

    :param filter: The filter to use to select the events
    :type filter: object
    :param events: The new events to insert
    :type events: list[~azure-iiot-opc-history.models.HistoricEventApiModel]
    """

    _validation = {
        'events': {'required': True},
    }

    _attribute_map = {
        'filter': {'key': 'filter', 'type': 'object'},
        'events': {'key': 'events', 'type': '[HistoricEventApiModel]'},
    }

    def __init__(self, events, filter=None):
        super(InsertEventsDetailsApiModel, self).__init__()
        self.filter = filter
        self.events = events
