import { SagaIterator } from 'redux-saga';
import { call, takeLatest } from 'redux-saga/effects';
import { get } from '../../../../../utils/networking';
import Actions from '../../actions';
import { IFetchFormLayout } from '../../actions/fetch';
import * as ActionTypes from '../../actions/types';
import QueueActions from '../../../../../shared/resources/queue/queueActions';

function* fetchFormLayoutSaga({ url }: IFetchFormLayout): SagaIterator {
  try {
    const { data }: any = yield call(get, url);
    yield call(
      Actions.fetchFormLayoutFulfilled,
      data.layout,
    );
  } catch (err) {
    yield call(Actions.fetchFormLayoutRejected, err);
    yield call(QueueActions.dataTaskQueueError, err);
  }

}

export function* watchFetchFormLayoutSaga(): SagaIterator {
  yield takeLatest(ActionTypes.FETCH_FORM_LAYOUT, fetchFormLayoutSaga);
}
